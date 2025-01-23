
using CompanyDetails.Helpers;
using CompanyDetails.ViewModel;

namespace CompanyDetails.IRepositories
{
    public interface IAuthRepository
    {
        Task<BaseResponseObject<object>> Login(LoginRequest entity);
        Task<BaseResponseObject<LoginResponse>> LoginVerifyOtp(VerifyOTPVM entity);

    }
}
