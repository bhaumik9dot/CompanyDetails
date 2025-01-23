using CompanyDetails.Data;
using CompanyDetails.Helpers;
using CompanyDetails.IRepositories;
using CompanyDetails.Models;
using CompanyDetails.Services;
using CompanyDetails.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CompanyDetails.Repositories
{
    public class CompanyDetailsRepository : ICompanyDetailsRepository
    {
        private readonly AppDbContext _dbContext;

        public CompanyDetailsRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        #region :: AddNewCompany ::
        public async Task<BaseResponse> AddNewCompany(AddUpdateCompanyInformationVM entity)
        {
            try
            {
                var companyInformation = new CompanyInformation
                {
                    CompanyName = entity.CompanyName,
                    AcquisitionDate = entity.AcquisitionDate,
                    PlatformFeatures = entity.PlatformFeatures,
                    IpAddressV4 = entity.IpAddressV4,
                    MacAddress = entity.MacAddress,
                    Canceled = entity.Canceled,
                    Suspended = entity.Suspended,
                    Email = entity.Email,
                    ApiBaseUrl = entity.ApiBaseUrl,
                    DemoAccountNodeId = entity.DemoAccountNodeId,
                    AndroidBuild = entity.AndroidBuild,
                    ForceUpgrade = entity.ForceUpgrade,
                    iOSBuild = entity.iOSBuild,
                    AccountsCreatorURL = entity.AccountsCreatorURL,
                    WhatsNew = entity.WhatsNew,
                    Address = entity.Address,
                    LogoUrl = entity.LogoUrl,
                    WebsiteUrl = entity.WebsiteUrl,
                    FacebookUrl = entity.FacebookUrl,
                    YouTubeUrl = entity.YouTubeUrl,
                    LinkedInUrl = entity.LinkedInUrl,
                    XUrl = entity.XUrl,
                    ContactNumber = entity.ContactNumber,
                    HelpPageUrl = entity.HelpPageUrl,
                    PrivacyPolicyUrl = entity.PrivacyPolicyUrl,
                    TermsOfServiceUrl = entity.TermsOfServiceUrl,
                    PhysicalAddress = entity.PhysicalAddress,
                    CreatedAt = DateTime.UtcNow
                };

                await _dbContext.AddAsync(companyInformation);
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = ResponseMessage.AddCompany
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region :: UpdateCompanyInformation ::
        public async Task<BaseResponse> UpdateCompanyInformation(AddUpdateCompanyInformationVM entity)
        {
            try
            {

                var companyInformation = await _dbContext.CompanyInformation.FirstOrDefaultAsync(x => x.CompanyId == entity.CompanyId);
                if (companyInformation == null)
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = ResponseMessage.CompanyNotFound
                    };
                }

                companyInformation.CompanyName = entity.CompanyName;
                companyInformation.AcquisitionDate = entity.AcquisitionDate;
                companyInformation.PlatformFeatures = entity.PlatformFeatures;
                companyInformation.IpAddressV4 = entity.IpAddressV4;
                companyInformation.MacAddress = entity.MacAddress;
                companyInformation.Canceled = entity.Canceled;
                companyInformation.Suspended = entity.Suspended;
                companyInformation.Email = entity.Email;
                companyInformation.ApiBaseUrl = entity.ApiBaseUrl;
                companyInformation.DemoAccountNodeId = entity.DemoAccountNodeId;
                companyInformation.AndroidBuild = entity.AndroidBuild;
                companyInformation.ForceUpgrade = entity.ForceUpgrade;
                companyInformation.iOSBuild = entity.iOSBuild;
                companyInformation.AccountsCreatorURL = entity.AccountsCreatorURL;
                companyInformation.WhatsNew = entity.WhatsNew;
                companyInformation.Address = entity.Address;
                companyInformation.LogoUrl = entity.LogoUrl;
                companyInformation.WebsiteUrl = entity.WebsiteUrl;
                companyInformation.FacebookUrl = entity.FacebookUrl;
                companyInformation.YouTubeUrl = entity.YouTubeUrl;
                companyInformation.LinkedInUrl = entity.LinkedInUrl;
                companyInformation.XUrl = entity.XUrl;
                companyInformation.ContactNumber = entity.ContactNumber;
                companyInformation.HelpPageUrl = entity.HelpPageUrl;
                companyInformation.PrivacyPolicyUrl = entity.PrivacyPolicyUrl;
                companyInformation.TermsOfServiceUrl = entity.TermsOfServiceUrl;
                companyInformation.PhysicalAddress = entity.PhysicalAddress;
                companyInformation.UpdatedAt = DateTime.UtcNow;

                _dbContext.CompanyInformation.Update(companyInformation);

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = ResponseMessage.UpdateCompany
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region :: GetCompanyInformation ::
        public async Task<BaseResponseModel<IEnumerable<AddUpdateCompanyInformationVM>>> GetAllCompanyDetails()
        {
            try
            {
                var companyInformation = await (from Com in _dbContext.CompanyInformation
                                                select new AddUpdateCompanyInformationVM
                                                {
                                                    CompanyId = Com.CompanyId,
                                                    CompanyName = Com.CompanyName,
                                                    AcquisitionDate = Com.AcquisitionDate,
                                                    PlatformFeatures = Com.PlatformFeatures,
                                                    IpAddressV4 = Com.IpAddressV4,
                                                    MacAddress = Com.MacAddress,
                                                    Canceled = Com.Canceled,
                                                    Suspended = Com.Suspended,
                                                    Email = Com.Email,
                                                    ApiBaseUrl = Com.ApiBaseUrl,
                                                    DemoAccountNodeId = Com.DemoAccountNodeId,
                                                    AndroidBuild = Com.AndroidBuild,
                                                    ForceUpgrade = Com.ForceUpgrade,
                                                    iOSBuild = Com.iOSBuild,
                                                    AccountsCreatorURL = Com.AccountsCreatorURL,
                                                    WhatsNew = Com.WhatsNew,
                                                    Address = Com.Address,
                                                    LogoUrl = Com.LogoUrl,
                                                    WebsiteUrl = Com.WebsiteUrl,
                                                    FacebookUrl = Com.FacebookUrl,
                                                    YouTubeUrl = Com.YouTubeUrl,
                                                    LinkedInUrl = Com.LinkedInUrl,
                                                    XUrl = Com.XUrl,
                                                    ContactNumber = Com.ContactNumber,
                                                    HelpPageUrl = Com.HelpPageUrl,
                                                    PrivacyPolicyUrl = Com.PrivacyPolicyUrl,
                                                    TermsOfServiceUrl = Com.TermsOfServiceUrl,
                                                    PhysicalAddress = Com.PhysicalAddress,
                                                    CreatedAt  = Com.CreatedAt,
                                                    UpdatedAt = Com.UpdatedAt
                                                }).ToListAsync();

                if (companyInformation == null)
                {
                    return new BaseResponseModel<IEnumerable<AddUpdateCompanyInformationVM>>
                    {
                        Success = false,
                        Message = ResponseMessage.CompanyNotFound
                    };
                }

                return new BaseResponseModel<IEnumerable<AddUpdateCompanyInformationVM>>
                {
                    Success = true,
                    Message = ResponseMessage.DataRetrieved,
                    TotalRecords = companyInformation.Count,
                    Data = companyInformation
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: GetCompanyDetailById ::
        public async Task<BaseResponseModel<AddUpdateCompanyInformationVM>> GetCompanyDetailById(int companyId)
        {
            var companyInformation = await _dbContext.CompanyInformation
                .Where(x => x.CompanyId == companyId)
                .Select(com => new AddUpdateCompanyInformationVM
                {
                    CompanyId = com.CompanyId,
                    CompanyName = com.CompanyName,
                    AcquisitionDate = com.AcquisitionDate,
                    PlatformFeatures = com.PlatformFeatures,
                    IpAddressV4 = com.IpAddressV4,
                    MacAddress = com.MacAddress,
                    Canceled = com.Canceled,
                    Suspended = com.Suspended,
                    Email = com.Email,
                    ApiBaseUrl = com.ApiBaseUrl,
                    DemoAccountNodeId = com.DemoAccountNodeId,
                    AndroidBuild = com.AndroidBuild,
                    ForceUpgrade = com.ForceUpgrade,
                    iOSBuild = com.iOSBuild,
                    AccountsCreatorURL = com.AccountsCreatorURL,
                    WhatsNew = com.WhatsNew,
                    Address = com.Address,
                    LogoUrl = com.LogoUrl,
                    WebsiteUrl = com.WebsiteUrl,
                    FacebookUrl = com.FacebookUrl,
                    YouTubeUrl = com.YouTubeUrl,
                    LinkedInUrl = com.LinkedInUrl,
                    XUrl = com.XUrl,
                    ContactNumber = com.ContactNumber,
                    HelpPageUrl = com.HelpPageUrl,
                    PrivacyPolicyUrl = com.PrivacyPolicyUrl,
                    TermsOfServiceUrl = com.TermsOfServiceUrl,
                    PhysicalAddress = com.PhysicalAddress,
                    CreatedAt = com.CreatedAt,
                    UpdatedAt = com.UpdatedAt
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (companyInformation == null)
            {
                return new BaseResponseModel<AddUpdateCompanyInformationVM>
                {
                    Success = false,
                    Message = ResponseMessage.CompanyNotFound,
                    Data = null
                };
            }

            return new BaseResponseModel<AddUpdateCompanyInformationVM>
            {
                Success = true,
                Data = companyInformation,
                TotalRecords = companyInformation == null ? 0 : 1
            };
        }

        #endregion

        #region :: DeleteCompanyDetailById ::
        public async Task<BaseResponse> DeleteCompanyDetailById(int companyId)
        {
            try
            {
                var companyInformation = await _dbContext.CompanyInformation
                    .FirstOrDefaultAsync(x => x.CompanyId == companyId);

                if (companyInformation == null)
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = ResponseMessage.CompanyNotFound
                    };
                }

                _dbContext.CompanyInformation.Remove(companyInformation);
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = ResponseMessage.CompanyDeletedSuccessfully
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = $"An error occurred while deleting the company: {ex.Message}"
                };
            }
        }

        #endregion
    }
}
