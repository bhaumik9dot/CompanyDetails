

using CompanyDetails.Data;
using CompanyDetails.Enums;
using CompanyDetails.Helpers;
using CompanyDetails.IRepositories;
using CompanyDetails.Models;
using CompanyDetails.Services;
using CompanyDetails.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CompanyDetails.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthRepository(AppDbContext dbContext, TokenService tokenService, IConfiguration configuration)
        {
            this._dbContext = dbContext;
            this._tokenService = tokenService;
            this._configuration = configuration;
        }


        public async Task<BaseResponseObject<object>> Login(LoginRequest entity)
        {
            try
            {
                LoginResponse tokenVM = new();

                var userDetailsMaster = await _dbContext.UserMaster.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == entity.Email.ToLower());

                if (userDetailsMaster == null)
                    return new BaseResponseObject<object> { Success = false, Message = ResponseMessage.UserNotFound };

                string platformName = entity.PlatformName.ToLower().Trim();

                bool IsPlatformAccessValid = (platformName == RoleType.Admin.ToString().ToLower()
                                                && (userDetailsMaster.RoleId == RoleType.Admin))
                                                || (platformName == RoleType.Client.ToString().ToLower() && userDetailsMaster.RoleId == RoleType.Client);

                if (!IsPlatformAccessValid)
                    return new BaseResponseObject<object> { Success = false, Message = ResponseMessage.AccessRestricted };

                bool IsUserCredentialsValid = EncryptionHelper.DecryptString(userDetailsMaster.Password) == entity.Password;

                if (!IsUserCredentialsValid)
                    return new BaseResponseObject<object> { Success = false, Message = ResponseMessage.PasswordNotMatch };

                if (!userDetailsMaster.IsActive)
                    return new BaseResponseObject<object> { Success = false, Message = ResponseMessage.UserInActive };
                if (userDetailsMaster.OtpDisable)
                {
                    return new BaseResponseObject<object> { Success = true, Message = ResponseMessage.WithOutOTPLogin, Data = new { OtpDisable = userDetailsMaster.OtpDisable } };
                }

                bool success = await GenerateOtp(userDetailsMaster.Email);
                //await SentOtp(user.UserId);

                return new BaseResponseObject<object>
                {
                    Success = success,
                    Message = success ? ResponseMessage.OTPSend : ResponseMessage.OTPNotSend
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResponseObject<LoginResponse>> LoginVerifyOtp(VerifyOTPVM entity)
        {
            try
            {
                LoginResponse tokenVM = new();

                var userDetailsMaster = await _dbContext.UserMaster.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == entity.Email);

                if (userDetailsMaster == null)
                    return new BaseResponseObject<LoginResponse> { Success = false, Message = ResponseMessage.UserNotFound };


                if (!userDetailsMaster.OtpDisable)
                {
                    if (userDetailsMaster.Otp != entity.OTP)
                        return new BaseResponseObject<LoginResponse> { Success = false, Message = ResponseMessage.IncorrectOTP };

                    DateTime currentTime = DateTime.UtcNow;
                    DateTime otpExpiryTime = Convert.ToDateTime(userDetailsMaster.OtpExpiryTime);

                    if (currentTime > otpExpiryTime)
                        return new BaseResponseObject<LoginResponse> { Success = false, Message = ResponseMessage.OTPExpired };
                }

                var token = await CreateUserToken(userDetailsMaster);

                if (token.Token != null)
                {

                    tokenVM.AuthToken = token.Token;
                    tokenVM.RoleId = token.RoleId;
                    tokenVM.ExpiredIn = Convert.ToInt32(_configuration["JwtConfig:accessTokenExpiration"]);
                    tokenVM.Role = token.RoleName;
                    tokenVM.Id = userDetailsMaster.UserId;
                    tokenVM.FirstName = userDetailsMaster.FirstName;
                    tokenVM.LastName = userDetailsMaster.LastName;
                    tokenVM.Email = userDetailsMaster.Email;
                    tokenVM.MobileNo = userDetailsMaster.PhoneNo;
                    tokenVM.IsActive = userDetailsMaster.IsActive;
                }

                return new BaseResponseObject<LoginResponse> { Data = tokenVM, Success = true, Message = ResponseMessage.VerifyOTP };
            }
            catch (Exception)
            {
                throw;
            }
        }

        // private method

        private async Task<bool> GenerateOtp(string Email)
        {
            try
            {
                //int otp = CommanHelper.GenerateOtp();

                int otp = 123456; // static otp please change before live 

                var userDetail = await _dbContext.UserMaster.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == Email.ToLower().Trim());

                if (userDetail != null)
                {
                    userDetail.Otp = otp;
                    userDetail.OtpExpiryTime = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["OTP:ExpirationTime"]));
                    _dbContext.UserMaster.Update(userDetail);
                }

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
                return true; // success
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private async Task SentOtp(int userId)
        //{
        //    var userEmail = await (from Um in _dbContext.UserMaster
        //                           where Um.UserId == userId
        //                           select new
        //                           {
        //                               FullName = Um.FirstName + " " + ,
        //                               Email = Um.Email,
        //                               Otp = Um.Otp,
        //                           }).FirstOrDefaultAsync();

        //    var email = await _emailManagerService.GetEmail(new UserMaster(), x => x.Email == userEmail.Email);

        //    await _emailManagerService.SendEmailAsync(EmailSubjectName.LoginOtp, email.Email, new[] { userEmail });
        //}
        private async Task<(string? RoleName, int RoleId, string? Token)> CreateUserToken(UserMaster userDetailsMaster)
        {
            string? RoleName = await (from role in _dbContext.RoleMaster
                                      where role.RoleId == (int)userDetailsMaster.RoleId
                                      select role.RoleName).AsNoTracking().FirstOrDefaultAsync();

            var token = _tokenService.GenerateToken(userDetailsMaster.UserId, RoleName, userDetailsMaster.Email);

            return (RoleName, (int)userDetailsMaster.RoleId, token);
        }
    }
}
