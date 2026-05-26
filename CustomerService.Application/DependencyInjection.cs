using AccountService.Application.Features.Accounts;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<CreateAccountHandler>();

            return services;
        }
    }
}
