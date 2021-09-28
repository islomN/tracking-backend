using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracking.Admin.Infrastructure.Services;

namespace Tracking.Admin.Controllers
{
    [Route("api-admin/operation-systems")]
    public class OperationSystemController: ControllerBase
    {
        private readonly IOperationSystemService _operationSystemService;

        public OperationSystemController(IOperationSystemService operationSystemService)
        {
            _operationSystemService = operationSystemService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _operationSystemService.Get();
        }
    }
}