using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tracking.Core
{
    public class EntityContextFactory: IDesignTimeDbContextFactory<EntityContext>
    {
        public EntityContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("contextSettings.json", false, true)
                .Build();

            var context = new EntityContext(configuration.GetSection("DbSection:ConnectionString").Value);
            return context;
        }
    }
}