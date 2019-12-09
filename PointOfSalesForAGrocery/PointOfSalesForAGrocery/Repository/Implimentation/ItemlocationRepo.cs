using POS.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository.Implimentation
{
    public class ItemlocationRepo
    {
        private readonly AppDbContext context;

        public ItemlocationRepo(AppDbContext context)
        {
            this.context = context;
        }
    }
}
