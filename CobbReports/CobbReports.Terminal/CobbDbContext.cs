//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CobbReports.Terminal
//{
//    public class CobbDbContext : DbContext
//    {
//        public DbSet<LoggerDataSet> DataSets { get; set; }
//        public DbSet<DataSetInfo> DataSetInfo { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseNpgsql("Server = localhost; Database = Cobb; User Id=postgres; Password=blue1234");
//        }
//    }
//}
