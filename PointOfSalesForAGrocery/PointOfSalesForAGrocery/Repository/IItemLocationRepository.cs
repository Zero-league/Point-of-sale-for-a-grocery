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
        Task<ItemLocation> PutItemLocation(int id);
        Task<ItemLocation> PostItemLocation();
        Task<ItemLocation> DeleteItemLocation(int id);
    }
}
