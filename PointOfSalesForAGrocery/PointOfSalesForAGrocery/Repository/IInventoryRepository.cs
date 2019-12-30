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
        Task<IEnumerable<ItemDto>> GetInventories();
        Task<ItemDto> GetInventory(int id);
        Task<Inventory> UpdateInventory(int id, InventoryDto c);
        Task<Inventory> PostInventory(InventoryDto inventoryDto);
        Task RemoveInventory(int id);


    }
}
