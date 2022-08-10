using HR.Department.IdentityServer4.Configuration;
using HR.Department.IdentityServer4.Data;
using HR.Department.IdentityServer4.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Department.IdentityServer4.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services) =>
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();


        public static void ConfigureIdentityServer(this IServiceCollection services) =>
            services.AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()
                .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                .AddInMemoryApiResources(IdentityServerConfiguration.GetApiResourses())
                .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResourses())
                .AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScopes())
                .AddProfileService<ProfileService>()
                .AddDeveloperSigningCredential();

    }
}
