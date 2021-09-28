using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracking.Admin.Infrastructure.ActionResults;
using Tracking.Admin.Infrastructure.Context;
using Tracking.Core;

namespace Tracking.Admin.Infrastructure.Services
{
    public class OperationSystemService: IOperationSystemService
    {
        private readonly AdminEntityContext _context;
        public OperationSystemService(AdminEntityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var operationSystems = await _context.OperationSystems.OrderBy(i => i.Name).ToListAsync();
                return new SuccessActionResult(operationSystems);
            }
            catch
            {
                return new ErrorActionResult("Service not available");
            }
            
        }
    }
}