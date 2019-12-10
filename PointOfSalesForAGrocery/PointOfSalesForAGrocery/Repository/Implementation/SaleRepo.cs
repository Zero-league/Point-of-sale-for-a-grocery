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
        public async Task<Sale> AddSale(Sale sale)
        {
            await _DbContext.Sale.AddAsync(sale);
            await _DbContext.SaveChangesAsync();
            var newsale = await GetSaleById(sale.Id);
            return newsale;
        }

        public async Task<Sale> DeleteSale(int id)
        {
            var removedsale = await GetSaleById(id);
            _DbContext.Sale.Remove(removedsale);
            await _DbContext.SaveChangesAsync();
            return removedsale;
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

        public async Task<Sale> UpdateSale(int id, Sale modifiedsale)
        {
            var sale = await GetSaleById(id);
            if(sale != null)
            {
                try
                {
                    sale.ItemsName = modifiedsale.ItemsName;
                    sale.Quantity = modifiedsale.Quantity;
                    sale.RetailPrice = modifiedsale.RetailPrice;
                    sale.SalesPerson = modifiedsale.SalesPerson;
                    sale.BillId = modifiedsale.BillId;

                    await _DbContext.SaveChangesAsync();

                    return sale;
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
