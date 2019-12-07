using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.DataSource;
using POS.Models;

namespace PointOfSalesForAGrocery.Repository
{
    public class InventoryRepo : IInventoryRepository
    {
        private readonly AppDbContext context;

        public InventoryRepo(AppDbContext context)
        {
            this.context = context;
        }
        public Task<ActionResult<IEnumerable<Inventory>>> GetItemCatogaries()
        {
            throw new NotImplementedException();
        }
    }
}
