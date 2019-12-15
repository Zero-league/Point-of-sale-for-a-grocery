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
            
        }

        public DbSet<Inventory>  Inventories { get; set; }
        public DbSet<ItemCatogary>  ItemCatogaries { get; set; }
        public DbSet<ItemLocation>  ItemLocations { get; set; }
        public DbSet<Unitmesurement>  Unitmesurements { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Sale> Sale { get; set; }
    }
}
