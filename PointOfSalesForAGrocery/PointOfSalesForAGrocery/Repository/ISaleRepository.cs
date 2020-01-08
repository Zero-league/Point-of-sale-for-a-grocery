using Microsoft.AspNetCore.Mvc;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetSales();
        Sale GetSaleById(int id);
        Sale UpdateSale(int id, Sale sale);
        bool AddSale(Sale sale);
        Sale DeleteSale(int id);
    }
}
