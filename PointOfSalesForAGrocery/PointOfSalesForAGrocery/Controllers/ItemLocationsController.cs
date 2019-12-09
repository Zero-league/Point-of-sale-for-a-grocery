﻿using System;
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
    public class ItemLocationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemLocationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemLocation>>> GetItemLocations()
        {
            return await _context.ItemLocations.ToListAsync();
        }

        // GET: api/ItemLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemLocation>> GetItemLocation(int id)
        {
            var itemLocation = await _context.ItemLocations.FindAsync(id);

            if (itemLocation == null)
            {
                return NotFound();
            }

            return itemLocation;
        }

        // PUT: api/ItemLocations/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemLocation(int id, ItemLocation itemLocation)
        {
            if (id != itemLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemLocationExists(id))
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

        // POST: api/ItemLocations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ItemLocation>> PostItemLocation(ItemLocation itemLocation)
        {
            _context.ItemLocations.Add(itemLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemLocation", new { id = itemLocation.Id }, itemLocation);
        }

        // DELETE: api/ItemLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemLocation>> DeleteItemLocation(int id)
        {
            var itemLocation = await _context.ItemLocations.FindAsync(id);
            if (itemLocation == null)
            {
                return NotFound();
            }

            _context.ItemLocations.Remove(itemLocation);
            await _context.SaveChangesAsync();

            return itemLocation;
        }

        private bool ItemLocationExists(int id)
        {
            return _context.ItemLocations.Any(e => e.Id == id);
        }
    }
}
