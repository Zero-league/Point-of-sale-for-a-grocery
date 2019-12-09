using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.Models;
using POS.Models.Entities;

namespace PointOfSalesForAGrocery.Repository
{
    public interface IInventoryRepository
    {
        Task<IEnumerable< Inventory>> GetInventories();
        Task<Inventory> GetInventory(int id);
        Task<Inventory> UpdateInventory(int id, InventoryDto inventoryDto);
        Task<Inventory> PostInventory( InventoryDto inventoryDto);
        Task<Inventory> RemoveInventory(int id);


    }
}
