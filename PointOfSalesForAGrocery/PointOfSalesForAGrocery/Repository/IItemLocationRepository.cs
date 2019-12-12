using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository
{
    public interface IItemLocationRepository
    {
        Task<IEnumerable<ItemLocation>> GetItemLocations();
        Task<ItemLocation> GetItemLocation(int id);
        Task<ItemLocation> PutItemLocation(int id, ItemLocationDto itemLocation);
        Task<ItemLocation> PostItemLocation(ItemLocation itemLocation);
        Task<ItemLocation> DeleteItemLocation(int id);
    }
}
