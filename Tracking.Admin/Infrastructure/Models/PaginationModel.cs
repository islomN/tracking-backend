using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tracking.Admin.Infrastructure.Models
{
    public class PaginationModel<T>
    {
        public const int PageCount = 20;
        public PaginationModel(IEnumerable<T> items, int count)
        {
            Items = items;
            Count = count;
        }
        
        public static async Task<PaginationModel<T>> Create(IQueryable<T> itemsQuery, int page)
        {
            if (page < 1)
            {
                page = 1;
            }
            
            var count = await itemsQuery.CountAsync();
            var items = await itemsQuery.Skip(PageCount * (page - 1)).Take(PageCount).ToListAsync();
            return new PaginationModel<T>(items, count);
        }

        public IEnumerable<T> Items { get; }
        
        public int Count { get; }
    }
}