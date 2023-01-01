using System;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Department.IdentityServer4.Data;

public class DatabaseInitializer
{
    public static void Init(IServiceProvider scopeServiceProvider)
    {
        var userManager = scopeServiceProvider.GetService<UserManager<IdentityUser>>();

        var user = new IdentityUser
        {
            UserName = "User"
        };

        var result = userManager.CreateAsync(user, "Password").GetAwaiter().GetResult();
        if (result.Succeeded)
        {
            userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin")).GetAwaiter().GetResult();
            userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Scope, "DepartmentAPI")).GetAwaiter().GetResult();
        }

    }

}