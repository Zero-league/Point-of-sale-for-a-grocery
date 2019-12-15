using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.DataSource;
using POS.Models;

namespace PointOfSalesForAGrocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;

        public SalesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            return await _context.Sale.ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSalesById(int id)
        {

            var sale = await _context.Sale.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }
        [HttpGet("item")]
        public async Task<ActionResult<IEnumerable< Inventory>>> GetSaleItem(string quarystring)
        {
            var salesitem = from m in _context.Inventories
                            select m;
            if (!string.IsNullOrEmpty(quarystring))
            {
                salesitem = salesitem.Where(i => i.ItemName.Contains(quarystring));
                return await salesitem.ToListAsync();
            }
            else
            {
                return BadRequest();
            }
            
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, Sale sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sales
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Sale>> AddSale( [FromBody] List<Inventory> inventories)
        {
            Sale sale = new Sale();
            try
            {
               
                foreach (var item in inventories)
                {
                    var it = mapper.Map(item, sale);
                    _context.Sale.Add(it);
                    await _context.SaveChangesAsync();

                    var Salaesitem = await _context.Inventories.Where(i => i.Id == item.Id).SingleOrDefaultAsync();

                    Salaesitem.QTY -= item.QTY;

                    _context.Entry(Salaesitem).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }


            }
            catch (Exception)
            {

                throw;
            }
           
            

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sale>> DeleteSale(int id)
        {
            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();

            return sale;
        }

        private bool SaleExists(int id)
        {
            return _context.Sale.Any(e => e.Id == id);
        }
    }
}
