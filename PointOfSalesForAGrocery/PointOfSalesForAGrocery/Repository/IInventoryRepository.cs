using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.Models;

namespace PointOfSalesForAGrocery.Repository
{
    public interface IInventoryRepository
    {
        Task<ActionResult<IEnumerable<Inventory>>> GetItemCatogaries();
    }
}
