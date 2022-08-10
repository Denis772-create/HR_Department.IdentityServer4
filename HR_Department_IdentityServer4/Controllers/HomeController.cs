using System.Threading.Tasks;
using HR.Department.IdentityServer4.ViewModels;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HR.Department.IdentityServer4.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IWebHostEnvironment _environment;


        public HomeController(IIdentityServerInteractionService interaction,
            IWebHostEnvironment environment)
        {
            _interaction = interaction;
            _environment = environment;
        }

        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;

                if (!_environment.IsDevelopment())
                    message.ErrorDescription = null;
            }

            return View("Error", vm);
        }

    }
}
