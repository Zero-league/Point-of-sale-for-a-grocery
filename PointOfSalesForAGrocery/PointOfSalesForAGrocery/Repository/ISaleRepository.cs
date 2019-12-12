using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetSales();
        Task<Sale> GetSaleById(int id);
        Task<Sale> UpdateSale(int id, Sale sale);
        Task<Sale> AddSale(Sale sale);
        Task<Sale> DeleteSale(int id);
    }
}
