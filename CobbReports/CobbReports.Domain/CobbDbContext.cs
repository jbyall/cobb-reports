using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CobbReports.Domain
{
    public class CobbDbContext : DbContext
    {
        public DbSet<LogInfo> LogInfos { get; set; }
        public DbSet<Log> Logs { get; set; }

        public CobbDbContext(DbContextOptions<CobbDbContext> options) :base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql();
        }
    }
}
