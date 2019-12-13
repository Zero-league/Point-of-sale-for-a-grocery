using Microsoft.EntityFrameworkCore;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DataSource
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Inventory>  Inventories { get; set; }
        public DbSet<ItemCatogary>  ItemCatogaries { get; set; }
        public DbSet<ItemLocation>  ItemLocations { get; set; }
        public DbSet<Unitmesurement>  Unitmesurements { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //string sqlConnectionString = "Server=DESKTOP-ES9JH7P;Database=POSSYSTEM;Trusted_Connection=True";

            //builder.UseSqlServer(sqlConnectionString);

            base.OnConfiguring(builder);
        }
    }
}
