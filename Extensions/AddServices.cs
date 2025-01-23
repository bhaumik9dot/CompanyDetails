


using CompanyDetails.IRepositories;
using CompanyDetails.Repositories;
using CompanyDetails.Services;

namespace CompanyDetails.Extensions
{
    public static class AddServices
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            // inject dependenacy

            services.AddScoped<TokenService>();
            services.AddHttpClient(); // Register HttpClientFactory

            // Repository
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ICompanyDetailsRepository, CompanyDetailsRepository>();
            
        }
    }
}
