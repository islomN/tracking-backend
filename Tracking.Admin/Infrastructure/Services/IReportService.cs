using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tracking.Admin.Infrastructure.Services
{
    public interface IReportService
    {
        Task<IActionResult> ByRequest(byte? os, int page, string traceId);

        Task<IActionResult> ByCountry(int page, string traceId);
    }
}