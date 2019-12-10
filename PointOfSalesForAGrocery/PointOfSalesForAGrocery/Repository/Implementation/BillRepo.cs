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

        public async Task<Bill> AddBill(Bill bill)
        {
            await _DbContext.Bill.AddAsync(bill);
            await _DbContext.SaveChangesAsync();
            var newbill = await GetBillById(bill.Id);
            return newbill;
        }

        public async Task<Bill> DeleteBill(int id)
        {
            var removedbill = await GetBillById(id);
            _DbContext.Bill.Remove(removedbill);
            await _DbContext.SaveChangesAsync();
            return removedbill;
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

        public async Task<Bill> UpdateBill(int id, Bill modifiedbill)
        {
            var bill = await GetBillById(id);
            if(bill != null)
            {
                try
                {
                    bill.DateTime = modifiedbill.DateTime;
                    bill.Amount = modifiedbill.Amount;
                    bill.Discount = modifiedbill.Discount;
                    bill.SalesPerson = modifiedbill.SalesPerson;

                    await _DbContext.SaveChangesAsync();

                    return bill;
                }
                catch(Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
