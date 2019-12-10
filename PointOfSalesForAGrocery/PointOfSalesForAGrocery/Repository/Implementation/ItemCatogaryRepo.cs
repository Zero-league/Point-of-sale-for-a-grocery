using POS.DataSource;
using POS.Models;
using POS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository.Implementation
{
    public class ItemCatogaryRepo : IItemCatogaryRepository
    {
        private readonly AppDbContext context;

        public ItemCatogaryRepo(AppDbContext context)
        {
            this.context = context;
        }

        public Task<ItemCatogary> DeleteItemCatogary(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemCatogary>> GetItemCatogaries()
        {
            throw new NotImplementedException();
        }

        public Task<ItemCatogary> GetItemCatogary(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemCatogary> PostItemCatogary(ItemCatogaryDto itemCatogaryDto)
        {
            throw new NotImplementedException();
        }

        public Task<ItemCatogary> UpdatetemCatogary(int id, ItemCatogaryDto itemCatogaryDto)
        {
            throw new NotImplementedException();
        }
    }
}
