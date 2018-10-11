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
    public class CommentDb : DbContext, IDesignTimeDbContextFactory<CommentDb>
    {
        public CommentDb() { }
        public CommentDb(DbContextOptions<CommentDb> options) : base(options)
        {

        }

        public DbSet<CommentModel> Comments { get; set; }

        public CommentDb CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<CommentDb>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new CommentDb(builder.Options);
        }
    }
}
