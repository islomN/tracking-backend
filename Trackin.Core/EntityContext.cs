using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tracking.Core.Tables;

namespace Tracking.Core
{
    public class EntityContext: BaseEntityContext
    {
        public EntityContext( IOptions<EntityContextOptions> options)
        {
            ConnectionString = options.Value.ConnectionString;
        }
        
        public EntityContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        
        public virtual DbSet<OperationSystem> OperationSystems { get; set; }
        
        public virtual DbSet<Tables.Tracking> Tracking { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationSystem>().HasIndex(o => o.Name).IsUnique();
            
            modelBuilder.Entity<Tables.Tracking>().HasIndex(o => o.ClientId).IsUnique();
            modelBuilder.Entity<Tables.Tracking>().HasIndex(o => o.ClientCountry);
            modelBuilder.Entity<Tables.Tracking>().HasIndex(o => o.SiteCountry);
            modelBuilder.Entity<Tables.Tracking>().HasIndex(o => o.RequestDate);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(IsUseLazyLoading)
                .UseSqlServer(
                    ConnectionString,
                    builder =>
                    {
                        builder.EnableRetryOnFailure(30, TimeSpan.FromSeconds(2), null);
                    });
        }
    }
}