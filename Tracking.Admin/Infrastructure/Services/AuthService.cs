using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracking.Admin.Infrastructure.ActionResults;
using Tracking.Admin.Infrastructure.Models;

namespace Tracking.Admin.Infrastructure.Services
{
    public class AuthService: IAuthService
    {
        public async Task<IActionResult> SignIn(SignInRequest request, string traceId)
        {
            return new SuccessActionResult(new SignInResponse());
        }
    }
}