using Microsoft.EntityFrameworkCore;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DataSource
{
    class DbContexts : DbContext
    {
        public DbContexts(DbContextOptions<DbContexts>options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Expenses> Expenses { get; set; }

        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string sqlConnectionString = "Server=;Database=;Trusted_Connection=True";

            builder.UseSqlServer(sqlConnectionString);

            base.OnConfiguring(builder);
        }
    }
}
