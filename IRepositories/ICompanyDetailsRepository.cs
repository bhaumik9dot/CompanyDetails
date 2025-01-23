using CompanyDetails.Helpers;
using CompanyDetails.ViewModel;
using System.Threading.Tasks;

namespace CompanyDetails.IRepositories
{
    public interface ICompanyDetailsRepository
    {
        Task<BaseResponse> AddNewCompany(AddUpdateCompanyInformationVM entity);
        Task<BaseResponse> UpdateCompanyInformation(AddUpdateCompanyInformationVM entity);
        Task<BaseResponseModel<IEnumerable<AddUpdateCompanyInformationVM>>> GetAllCompanyDetails();
        Task<BaseResponseModel<AddUpdateCompanyInformationVM>> GetCompanyDetailById(int CompanyId);
        Task<BaseResponse> DeleteCompanyDetailById(int CompanyId);
    }
}
