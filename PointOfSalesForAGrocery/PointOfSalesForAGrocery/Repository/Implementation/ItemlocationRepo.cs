using POS.DataSource;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository.Implementation
{
    public class ItemlocationRepo : IItemLocationRepository
    {
        private readonly AppDbContext context;

        public ItemlocationRepo(AppDbContext context)
        {
            this.context = context;
        }

        public Task<ItemLocation> DeleteItemLocation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemLocation> GetItemLocation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemLocation>> GetItemLocations()
        {
            throw new NotImplementedException();
        }

        public Task<ItemLocation> PostItemLocation()
        {
            throw new NotImplementedException();
        }

        public Task<ItemLocation> PutItemLocation(int id)
        {
            throw new NotImplementedException();
        }
    }
}
