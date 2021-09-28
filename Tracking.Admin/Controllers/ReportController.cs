using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracking.Admin.Infrastructure.Services;

namespace Tracking.Admin.Controllers
{
    [Route("api-admin/report")]
    public class ReportController: ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("by-request")]
        public async Task<IActionResult> ByRequest(byte? os, int page)
        {
            return await _reportService.ByRequest(os, page, HttpContext.TraceIdentifier);
        }

        [HttpGet("by-country")]
        public async Task<IActionResult> ByCountry(int page)
        {
            return await _reportService.ByCountry(page, HttpContext.TraceIdentifier);
        }
    }
}