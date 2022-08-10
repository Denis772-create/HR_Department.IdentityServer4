using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace HR.Department.IdentityServer4.Configuration
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
            {
                ClientId = "hr_department_mvc_id",
                ClientSecrets = {new Secret("hr_department_mvc_secret".ToSha256())},

                AllowedGrantTypes = GrantTypes.Code,

                AllowedScopes =
                {
                    "DepartmentAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },

                RedirectUris = { "https://localhost:5011/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5011/signout-callback-oidc" },

                RequireConsent = false,

                AccessTokenLifetime = 60,

                AllowOfflineAccess = true
            }
        };

        public static IEnumerable<ApiResource> GetApiResourses()
        {
            yield return new ApiResource("DepartmentAPI");
        }

        public static IEnumerable<IdentityResource> GetIdentityResourses()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            yield return new ApiScope("DepartmentAPI", "HR Department API");
        }
    }
}
