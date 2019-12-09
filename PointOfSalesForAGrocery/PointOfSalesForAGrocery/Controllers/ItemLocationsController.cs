﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSalesForAGrocery.Repository;
using POS.DataSource;
using POS.Models;
using POS.Models.Entities;

namespace PointOfSalesForAGrocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemLocationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IItemLocationRepository _itemLocationRepository;

        public ItemLocationsController(AppDbContext context, IItemLocationRepository itemLocationRepository )
        {
            _context = context;
            _itemLocationRepository = itemLocationRepository;
        }

        // GET: api/ItemLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemLocation>>> GetItemLocations()
        {
            var GetItemLocations = await _itemLocationRepository.GetItemLocations();

            return Ok(GetItemLocations);
        }

        // GET: api/ItemLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemLocation>> GetItemLocation(int id)
        {
            var itemLocation = await _itemLocationRepository.GetItemLocation(id);

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
        public async Task<IActionResult> PutItemLocation(int id,[FromBody] ItemLocationDto itemLocation)
        {
            if (itemLocation ==null)
            {
                return BadRequest();
            }



            try
            {
                await _itemLocationRepository.PutItemLocation(id);
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
        public async Task<ActionResult<ItemLocation>> PostItemLocation([FromBody] ItemLocationDto itemLocation)
        {

          var post =  await _itemLocationRepository.PostItemLocation();

            return CreatedAtAction("GetItemLocation", new { id = post.Id }, itemLocation);
        }

        // DELETE: api/ItemLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemLocation>> DeleteItemLocation(int id)
        {
            var itemLocation = await _itemLocationRepository.GetItemLocation(id);
            if (itemLocation == null)
            {
                return NotFound();
            }


            await _itemLocationRepository.DeleteItemLocation(id);

            return itemLocation;
        }

        private bool ItemLocationExists(int id)
        {
            return _context.ItemLocations.Any(e => e.Id == id);
        }
    }
}
