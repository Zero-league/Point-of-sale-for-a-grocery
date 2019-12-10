using Microsoft.EntityFrameworkCore;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DataSource
{
    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options) : base(options)
        {
            
        }

        public DbSet<Bill> Bill { get; set; }
        public DbSet<Sale> Sale { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    string SqlConnectionString = "Server=.\\SQLEXPRESS; Database=PointofSaleDB; Trusted_Connection=True";
        //    builder.UseSqlServer(SqlConnectionString);
        //    base.OnConfiguring(builder);
        //}
    }
}
