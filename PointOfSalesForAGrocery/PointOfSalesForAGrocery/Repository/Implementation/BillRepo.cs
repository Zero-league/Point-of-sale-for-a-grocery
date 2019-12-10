using Microsoft.EntityFrameworkCore;
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

        public async Task<Bill> GetBillById(int id)
        {
            var bill = await _DbContext.Bill.Where(c => c.Id == id).SingleOrDefaultAsync();
            return bill;
        }

        public async Task<IEnumerable<Bill>> GetBills()
        {
            var bills = await _DbContext.Bill.ToListAsync();
            return bills;
        }

        public Task<Bill> UpdateBill(int id, Bill bill)
        {
            throw new NotImplementedException();
        }
    }
}
