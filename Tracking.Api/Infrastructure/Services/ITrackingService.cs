using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracking.Api.Infrastructure.Models;

namespace Tracking.Api.Infrastructure.Services
{
    public interface ITrackingService
    {
        Task<IActionResult> Save(TrackingRequest request, string traceId);
    }
}