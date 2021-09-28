using System;
using System.Net;
using System.Threading.Tasks;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tracking.Api.Infrastructure.ActionResults;
using Tracking.Api.Infrastructure.Models;
using Tracking.Core;

namespace Tracking.Api.Infrastructure.Services
{
    public class TrackingService: ITrackingService
    {
        private const string SecretToken = "secret-token";

        private readonly ILogger<TrackingService> _logger;
        private readonly WebServiceClient _maxMindClient;
        private readonly EntityContext _context;
        
        public TrackingService(ILogger<TrackingService> logger, WebServiceClient maxMindClient, EntityContext context)
        {
            _logger = logger;
            _maxMindClient = maxMindClient;
            _context = context;
        }
        
        public async Task<IActionResult> Save(TrackingRequest request, string traceId)
        {
            request.ClientId = Guid.NewGuid().ToString();
            if (request.Secret != SecretToken)
            {
                return new ErrorActionResult("Secret not valid", HttpStatusCode.Forbidden);
            }

            var hasClientResult = await HasClient(request.ClientId, traceId);
            if (!hasClientResult.Success)
            {
                return new ErrorActionResult(hasClientResult.Message);
            }

            /*if (hasClientResult.Result != false)
            {
                return new SuccessActionResult("Duplicate");
            }*/
            
            var clientIpResult = await GetCountryCode(request.ClientIP, traceId);
            if (!clientIpResult.Success)
            {
                return new ErrorActionResult(clientIpResult.Message);
            }

            if (clientIpResult.Result == null)
            {
                return new ErrorActionResult("Client country not found, please check your client ip");
            }

            var siteIpResult = await GetCountryCode(request.ClientIP, traceId);
            if (!siteIpResult.Success)
            {
                return new ErrorActionResult(siteIpResult.Message);
            }

            if (siteIpResult.Result == null)
            {
                return new ErrorActionResult("Site country not found, please check your site ip", HttpStatusCode.BadRequest);
            }

            var osResult = await GetOs(request.OS, traceId);
            if (!osResult.Success)
            {
                return new ErrorActionResult(osResult.Message);
            }

            if (osResult.Result == null)
            {
                return new ErrorActionResult("os not found", HttpStatusCode.BadRequest);
            }

            var result = await SaveRequest(request.ClientId, request.ClientIP, clientIpResult.Result, request.Domain, (byte)osResult.Result, request.SiteIP, siteIpResult.Result, traceId);
            if (!result.Success)
            {
                return new ErrorActionResult(result.Message);
            }
            
            return new SuccessActionResult(HttpStatusCode.OK);
        }

        private async Task<TBaseResult<bool>> SaveRequest(string clientId, string clientIp, string clientCountry, string domain, byte os, string siteIp, string siteCountry, string traceId)
        {
            try
            {
                var tracking = new Core.Tables.Tracking(clientId, clientIp, clientCountry, siteIp, siteCountry, os, domain);
                _context.Tracking.Add(tracking);
                await _context.SaveChangesAsync();
                return new TBaseResult<bool>(true);
            }
            catch(Exception ex)
            {
                _logger.LogError(traceId + "\n\rMessage: "+ex.Message);
                return new TBaseResult<bool>(false, "Service not available");
            }
        }

        private async Task<TBaseResult<bool?>> HasClient(string clientId, string traceId)
        {
            try
            {
                var hasClientRequest = await _context.Tracking.AnyAsync(i => i.ClientId == clientId);
                return new TBaseResult<bool?>(true, hasClientRequest);
            }
            catch(Exception ex)
            {
                _logger.LogError(traceId + "\n\rMessage: "+ex.Message);
                return new TBaseResult<bool?>(false, null, "Service not available");
            }
        }

        private async Task<TBaseResult<byte?>> GetOs(string os, string traceId)
        {
            try
            {
                var osModel = await _context.OperationSystems.FirstOrDefaultAsync(i => i.Name == os);
                return new TBaseResult<byte?>(true, osModel?.Id);
            }
            catch(Exception ex)
            {
                _logger.LogError(traceId + "\n\rMessage: "+ex.Message);
                return new TBaseResult<byte?>(false, "Service not available");
            }
        }

        private async Task<TBaseResult<string>> GetCountryCode(string ip, string traceId)
        {
            try
            {
                var response =  await _maxMindClient.CountryAsync(ip);
                return new TBaseResult<string>(true, response.Country.IsoCode, null);
            }
            catch(Exception ex)
            {
                _logger.LogError(traceId + "\n\rMessage: "+ex.Message);
                return new TBaseResult<string>(true, "Service not available");
            }
        }
        
    }
}