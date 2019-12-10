using Microsoft.EntityFrameworkCore;
using POS.DataSource;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository.Implementation
{
    public class SaleRepo : ISaleRepository
    {
        private readonly POSDbContext _DbContext;
        public SaleRepo(POSDbContext DbContext)
        {
            this._DbContext = DbContext;
        }
        public Task<Sale> AddSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Task<Sale> DeleteSale(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Sale> GetSaleById(int id)
        {
            var sale = await _DbContext.Sale.Where(c => c.Id == id).SingleOrDefaultAsync();
            return sale;
        }

        public async Task<IEnumerable<Sale>> GetSales()
        {
            var sales = await _DbContext.Sale.ToListAsync();
            return sales;
        }

        public Task<Sale> UpdateSale(int id, Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
