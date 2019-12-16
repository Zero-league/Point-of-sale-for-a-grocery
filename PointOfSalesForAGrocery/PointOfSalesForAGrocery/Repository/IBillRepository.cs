using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository
{
    public interface IBillRepository
    {
        IEnumerable<Bill> GetBills();
        Bill GetBillById(int id);
        Bill UpdateBill(int id, Bill bill);
        Bill AddBill(Bill bill);
        Bill DeleteBill(int id);
    }
}
