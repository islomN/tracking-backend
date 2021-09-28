using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracking.Admin.Infrastructure.ActionResults;
using Tracking.Admin.Infrastructure.Context;
using Tracking.Admin.Infrastructure.Models;

namespace Tracking.Admin.Infrastructure.Services
{
    public class ReportService: IReportService
    {
        private readonly AdminEntityContext _context;

        public ReportService(AdminEntityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ByRequest(byte? os, int page, string traceId)
        {
            try
            {
                var query = _context.Tracking.AsQueryable();

                if (os != null)
                {
                    query = query.Where(i => i.OperationSystemId == os);
                }

                var reportQuery = query.OrderByDescending(i => i.RequestDate)
                    .Join(_context.OperationSystems,
                    t => t.OperationSystemId,
                    o => o.Id,
                    (t, o) => new RequestReportModel(t.ClientId, t.ClientIp, t.ClientCountry, t.RequestDate, t.Domain,
                        o.Name, t.SiteCountry)
                );

                return new SuccessActionResult(await PaginationModel<RequestReportModel>.Create(reportQuery, page));
            }
            catch
            {
                return new ErrorActionResult("Service not available");
            }
        }

        public async Task<IActionResult> ByCountry(int page, string traceId)
        {
            try
            {
                var items = await _context.Set<CountryReportModel>().FromSqlRaw(
                    @"select [client_country], count([request_date]) as requests, count(*) over() count from [tracking].[dbo].[tracking] group by [client_country] order by [client_country] offset {0} rows fetch next {1} rows only;", page-1, PaginationModel<CountryReportModel>.PageCount
                ).ToListAsync();
                
                return new SuccessActionResult(new PaginationModel<CountryReportModel>(items, items.FirstOrDefault()?.Count ?? 0));
            }
            catch
            { 
                return new ErrorActionResult("Service not available");
            }
        }
    }
}