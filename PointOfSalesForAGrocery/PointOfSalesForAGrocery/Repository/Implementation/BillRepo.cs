using POS.DataSource;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository.Implementation
{
    public class BillRepo : IBillRepository
    {
        private readonly POSDbContext _DbContext;
        public BillRepo(POSDbContext DbContext)
        {
            this._DbContext = DbContext;
        }

        public Task<Bill> AddBill(Bill bill)
        {
            throw new NotImplementedException();
        }

        public Task<Bill> DeleteBill(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Bill> GetBillById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bill>> GetBills()
        {
            throw new NotImplementedException();
        }

        public Task<Bill> UpdateBill(int id, Bill bill)
        {
            throw new NotImplementedException();
        }
    }
}
