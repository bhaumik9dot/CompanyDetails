using CompanyDetails.Helpers;
using CompanyDetails.IRepositories;
using CompanyDetails.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyInformationController : BaseController
    {
        private readonly ICompanyDetailsRepository _companyDetailsRepository;

        public CompanyInformationController(ICompanyDetailsRepository companyDetailsRepository)
        {
            _companyDetailsRepository = companyDetailsRepository;
        }

        [HttpPost]
        [Route("add-new-company")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewCompany([FromBody] AddNewCompanyDetalis entity)
        {
            var result = await _companyDetailsRepository.AddNewCompany(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        [HttpPut]
        [Route("update-company-information")]
        [Authorize]
        public async Task<IActionResult> UpdateCompanyInformation([FromBody] AddUpdateCompanyInformationVM entity)
        {
            var result = await _companyDetailsRepository.UpdateCompanyInformation(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        [HttpGet]
        [Route("get-all-company-detil")]
        [Authorize]
        public async Task<IActionResult> GetAllCompanyDetails()
        {
            var result = await _companyDetailsRepository.GetAllCompanyDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        [HttpGet]
        [Route("get-company-detail-by-id/{CompanyId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompanyDetailById(int CompanyId)
        {
            var result = await _companyDetailsRepository.GetCompanyDetailById(CompanyId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("delete-company-detail-by-id/{CompanyId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCompanyDetailById(int CompanyId)
        {
            var result = await _companyDetailsRepository.DeleteCompanyDetailById(CompanyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }
    }
}
