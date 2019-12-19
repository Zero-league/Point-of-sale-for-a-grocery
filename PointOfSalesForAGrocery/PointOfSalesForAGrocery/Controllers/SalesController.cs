using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSalesForAGrocery.Repository;
using POS.DataSource;
using POS.Models;

namespace PointOfSalesForAGrocery.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ISaleRepository _saleRepository;

        public SalesController(AppDbContext context, ISaleRepository saleRepository)
        {
            _context = context;
            this._saleRepository = saleRepository;
        }

        [HttpGet]
        public IActionResult GetSales()
        {
            var sales = _context.Sale.ToList();

            return Ok(sales);
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleById(int id)
        {
            var sale = _saleRepository.GetSaleById(id);

            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, [FromBody] Sale sale)
        {
            if (sale == null)
            {
                return BadRequest();
            }
            
            try
            {
                var update =  _saleRepository.UpdateSale(id, sale);
                if(update != null)
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                
                    throw;
                
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult AddSale(List<Sale> sale)
        {
            

            if (sale != null)
            {
              _saleRepository.AddSale(sale);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            var sale = _saleRepository.DeleteSale(id);
            if (sale == null)
            {
                return BadRequest();
            }

            return Ok();
        }

      
    }
}
