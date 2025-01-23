using CompanyDetails.Data;
using CompanyDetails.IRepositories;
using CompanyDetails.Services;

namespace CompanyDetails.Repositories
{
    public class CompanyDetailsRepository : ICompanyDetailsRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;

        public CompanyDetailsRepository(AppDbContext dbContext, TokenService tokenService, IConfiguration configuration)
        {
            this._dbContext = dbContext;
            this._tokenService = tokenService;
            this._configuration = configuration;
        }

    }
}
