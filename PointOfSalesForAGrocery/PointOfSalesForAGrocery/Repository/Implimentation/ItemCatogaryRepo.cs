using POS.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository.Implimentation
{
    public class ItemCatogaryRepo : IItemCatogaryRepository
    {
        private readonly AppDbContext context;

        public ItemCatogaryRepo(AppDbContext context)
        {
            this.context = context;
        }
    }
}
