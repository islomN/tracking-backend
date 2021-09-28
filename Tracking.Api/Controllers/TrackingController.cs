using System.Threading.Tasks;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Mvc;
using Tracking.Api.Infrastructure.Models;
using Tracking.Api.Infrastructure.Services;

namespace Tracking.Api.Controllers
{
    [Route("api/tracking")]
    public class TrackingController: ControllerBase
    {
        private readonly ITrackingService _trackingService;

        public TrackingController(ITrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        [HttpGet("feed")]
        public async Task<IActionResult> Feed(TrackingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please, check parameters or headers for the right data!");
            }

            return await _trackingService.Save(request, HttpContext.TraceIdentifier);
        }
    }
}