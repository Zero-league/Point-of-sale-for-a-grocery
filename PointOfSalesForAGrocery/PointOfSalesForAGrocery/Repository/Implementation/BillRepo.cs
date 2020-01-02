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

        public Bill AddBill(Bill bill,List<Sale> sale)
        {
            float amo = 0;
            if (sale != null)
            {
                foreach (var item in sale)
                {
                    amo += item.RetailPrice;

                }
            }
            if (bill != null)
            {
                if (bill.Discount != 0)
                {
                    Bill bill1 = new Bill();
                    bill1.NetAmount = amo;
                    bill1.GroceAmount = amo * ((100 - bill.Discount) / 100);
                    bill1.DateTime = bill.DateTime;
                    bill1.Discount = bill.Discount;
                    bill1.SalesPerson = bill.SalesPerson;

                    _DbContext.Bill.Add(bill1);
                    _DbContext.SaveChanges();
                }
                else
                {
                    Bill bill1 = new Bill();
                    bill1.NetAmount = amo;
                    bill1.GroceAmount = amo;
                    bill1.DateTime = bill.DateTime;
                    bill1.Discount = bill.Discount;
                    bill1.SalesPerson = bill.SalesPerson;

                    _DbContext.Bill.Add(bill);
                    _DbContext.SaveChanges();
                }


            }
            
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
                    bill.NetAmount = modifiedbill.NetAmount;
                    bill.GroceAmount = modifiedbill.GroceAmount;
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
