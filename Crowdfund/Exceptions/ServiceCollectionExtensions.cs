using Microsoft.Extensions.DependencyInjection;
using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.Services;

namespace Crowdfund.Exceptions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCrowdfund(
            this IServiceCollection services)
        {
            services.AddDbContext<CrowdfundDbContext>();
            services.AddScoped<IBackerService, BackerServices>();
            services.AddScoped<IMediaService, MediaServices>();
            services.AddScoped<IProjectService, ProjectServices>();
            services.AddScoped<IProjectCreatorService, ProjectCreatorServices>();
            services.AddScoped<IRewardPackageService, RewardPackageServices>();
            services.AddScoped<ITransactionService, TransactionServices>();
            services.AddScoped<ILoginService, LoginServices>();


        }
    }
}
