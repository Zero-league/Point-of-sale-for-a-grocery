using POS.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository.Implimentation
{
    public class UnitMesurementRepo
    {
        private readonly AppDbContext context;

        public UnitMesurementRepo(AppDbContext context)
        {
            this.context = context;
        }
    }
}
