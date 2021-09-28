using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tracking.Admin.Infrastructure.Services
{
    public interface IOperationSystemService
    {
        Task<IActionResult> Get();
    }
}