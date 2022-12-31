using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.Department.IdentityServer4.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/problem+json")]
[Authorize]
public class TestApiController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new[] { "It works fine!" });
}