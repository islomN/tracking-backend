using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracking.Admin.Infrastructure.Models;
using Tracking.Admin.Infrastructure.Services;

namespace Tracking.Admin.Controllers
{
    [Route("api-admin/auth")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            return await _authService.SignIn(request, HttpContext.TraceIdentifier);
        }
    }
}