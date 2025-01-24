using CompanyDetails.Helpers;
using CompanyDetails.ViewModel;
using System.Threading.Tasks;

namespace CompanyDetails.IRepositories
{
    public interface ICompanyDetailsRepository
    {
        Task<BaseResponse> AddNewCompany(CompanyInformationVM entity);
        Task<BaseResponse> UpdateCompanyInformation(CompanyInformationVM entity);
        Task<BaseResponseModel<IEnumerable<CompanyInformationVM>>> GetAllCompanyDetails();
        Task<BaseResponseModel<CompanyInformationVM>> GetCompanyDetailById(int CompanyId);
        Task<BaseResponse> DeleteCompanyDetailById(int CompanyId);
    }
}
