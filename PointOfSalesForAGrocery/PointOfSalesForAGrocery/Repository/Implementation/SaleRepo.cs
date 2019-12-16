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
        private readonly AppDbContext _DbContext;
        public SaleRepo(AppDbContext DbContext)
        {
            this._DbContext = DbContext;
        }
        public Sale AddSale(Sale sale)
        {
            _DbContext.Sale.Add(sale);
             _DbContext.SaveChanges();
            var newsale = GetSaleById(sale.Id);
            return newsale;
        }

        public Sale DeleteSale(int id)
        {
            var removedsale = GetSaleById(id);
            _DbContext.Sale.Remove(removedsale);
            _DbContext.SaveChanges();
            return removedsale;
        }

        public Sale GetSaleById(int id)
        {
            var sale = _DbContext.Sale.Where(c => c.Id == id).SingleOrDefault();
            return sale;
        }

        public IEnumerable<Sale> GetSales()
        {
            var sales = _DbContext.Sale.ToList();
            return sales;
        }

        public Sale UpdateSale(int id, Sale modifiedsale)
        {
            var sale =  GetSaleById(id);
            if(sale != null)
            {
                try
                {
                    sale.ItemsName = modifiedsale.ItemsName;
                    sale.Quantity = modifiedsale.Quantity;
                    sale.RetailPrice = modifiedsale.RetailPrice;
                    sale.SalesPerson = modifiedsale.SalesPerson;
                    sale.BillId = modifiedsale.BillId;

                    _DbContext.SaveChanges();

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
