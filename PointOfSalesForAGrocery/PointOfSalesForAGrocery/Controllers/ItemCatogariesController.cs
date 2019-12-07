using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.DataSource;
using POS.Models;

namespace PointOfSalesForAGrocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCatogariesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemCatogariesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemCatogaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCatogary>>> GetItemCatogaries()
        {
            return await _context.ItemCatogaries.ToListAsync();
        }

        // GET: api/ItemCatogaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCatogary>> GetItemCatogary(int id)
        {
            var itemCatogary = await _context.ItemCatogaries.FindAsync(id);

            if (itemCatogary == null)
            {
                return NotFound();
            }

            return itemCatogary;
        }

        // PUT: api/ItemCatogaries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemCatogary(int id, ItemCatogary itemCatogary)
        {
            if (id != itemCatogary.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemCatogary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCatogaryExists(id))
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

        // POST: api/ItemCatogaries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ItemCatogary>> PostItemCatogary(ItemCatogary itemCatogary)
        {
            _context.ItemCatogaries.Add(itemCatogary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemCatogary", new { id = itemCatogary.Id }, itemCatogary);
        }

        // DELETE: api/ItemCatogaries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemCatogary>> DeleteItemCatogary(int id)
        {
            var itemCatogary = await _context.ItemCatogaries.FindAsync(id);
            if (itemCatogary == null)
            {
                return NotFound();
            }

            _context.ItemCatogaries.Remove(itemCatogary);
            await _context.SaveChangesAsync();

            return itemCatogary;
        }

        private bool ItemCatogaryExists(int id)
        {
            return _context.ItemCatogaries.Any(e => e.Id == id);
        }
    }
}
