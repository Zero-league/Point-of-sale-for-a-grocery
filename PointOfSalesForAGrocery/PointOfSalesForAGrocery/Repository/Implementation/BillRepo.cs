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
        private readonly AppDbContext _DbContext;
        public BillRepo(AppDbContext DbContext)
        {
            this._DbContext = DbContext;
        }

        public Bill AddBill(Bill bill)
        {
            _DbContext.Bill.Add(bill);
            _DbContext.SaveChanges();
            var newbill = GetBillById(bill.Id);
            return newbill;
        }

        public Bill DeleteBill(int id)
        {
            var removedbill = GetBillById(id);
            _DbContext.Bill.Remove(removedbill);
             _DbContext.SaveChanges();
            return removedbill;
        }

        public Bill GetBillById(int id)
        {
            var bill = _DbContext.Bill.Where(c => c.Id == id).SingleOrDefault();
            return bill;
        }

        public IEnumerable<Bill> GetBills()
        {
            var bills = _DbContext.Bill.ToList();
            return bills;
        }

        public Bill UpdateBill(int id, Bill modifiedbill)
        {
            var bill =  GetBillById(id);
            if(bill != null)
            {
                try
                {
                    bill.DateTime = modifiedbill.DateTime;
                    bill.Amount = modifiedbill.Amount;
                    bill.Discount = modifiedbill.Discount;
                    bill.SalesPerson = modifiedbill.SalesPerson;

                     _DbContext.SaveChanges();

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
