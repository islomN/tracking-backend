using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracking.Admin.Infrastructure.Models;

namespace Tracking.Admin.Infrastructure.Services
{
    public interface IAuthService
    {
        Task<IActionResult> SignIn(SignInRequest request, string traceId);
    }
}