using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.DataSource;
using POS.Models;
using POS.Models.Entities;

namespace PointOfSalesForAGrocery.Repository
{
    public class InventoryRepo : IInventoryRepository
    {
        private readonly AppDbContext context;

        public InventoryRepo(AppDbContext context)
        {
            this.context = context;
        }

        public Task<IEnumerable<Inventory>> GetInventories()
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> GetInventory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> PostInventory(InventoryDto inventoryDto)
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> RemoveInventory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> UpdateInventory(int id, InventoryDto inventoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
