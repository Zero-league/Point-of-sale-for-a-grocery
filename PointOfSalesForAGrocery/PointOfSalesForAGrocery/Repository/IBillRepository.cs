using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository
{
    public interface IBillRepository
    {
        Task<IEnumerable<Bill>> GetBills();
        Task<Bill> GetBillById(int id);
        Task<Bill> UpdateBill(int id, Bill bill);
        Task<Bill> AddBill(Bill bill);
        Task<Bill> DeleteBill(int id);
    }
}
