using AutoMapper;
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
        private readonly IMapper mapper;

        public SaleRepo(AppDbContext DbContext, IMapper mapper)
        {
            this._DbContext = DbContext;
            this.mapper = mapper;
        }

        public bool AddSale(Sale sale)
        {
             _DbContext.Sale.Add(sale);
            var addSale = _DbContext.SaveChanges();

            return addSale > 0 ? true : false;
        }

        //public Sale DeleteSale(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Sale GetSaleById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Sale> GetSales()
        //{
        //    throw new NotImplementedException();
        //}

        //public Sale UpdateSale(int id, Sale sale)
        //{
        //    throw new NotImplementedException();
        //}
        //public void AddSale(List<Sale> sale)
        //{
        //    Sale s = new Sale();
        //    try
        //    {

        //        foreach (var item in sale)
        //        {
        //            var it = mapper.Map(item, s);
        //            _DbContext.Sale.Add(it);
        //            _DbContext.SaveChanges();

        //            var Salaesitem = _DbContext.Inventories.Where(i => i.Id == item.Id).SingleOrDefault();

        //            Salaesitem.QTY -= item.Quantity;

        //            _DbContext.Entry(Salaesitem).State = EntityState.Modified;
        //             _DbContext.SaveChanges();
        //        }


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        //_DbContext.Sale.Add(sale);
        // _DbContext.SaveChanges();
        //var newsale = GetSaleById(sale.Id);
        //return newsale;
    //}

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
