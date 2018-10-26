using MarsThreeSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarsThreeSite.Data
{
    public class SiteDb : DbContext, IDesignTimeDbContextFactory<SiteDb>
    {
        public SiteDb(DbContextOptions<SiteDb> options) : base(options) { }

        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<PageModel> Pages { get; set; }

        public SiteDb CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<SiteDb>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new SiteDb(builder.Options);
        }
    }
}
