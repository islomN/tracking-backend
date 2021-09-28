using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tracking.Admin.Infrastructure.Models;
using Tracking.Core;

namespace Tracking.Admin.Infrastructure.Context
{
    public class AdminEntityContext: EntityContext
    {
        public AdminEntityContext(IOptions<EntityContextOptions> options) : base(options)
        {
        }

        public AdminEntityContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<CountryReportModel> CountryReport { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CountryReportModel>().HasNoKey();
        }
        
    }
}