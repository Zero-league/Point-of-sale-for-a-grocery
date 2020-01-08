using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSalesForAGrocery.Repository;
using POS.DataSource;
using POS.Models;
using POS.Models.Entities;

namespace PointOfSalesForAGrocery.Controllers
{
    [Route("api")]
    public class ItemLocationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IItemLocationRepository _itemLocationRepository;
        private readonly IMapper mapper;

        public ItemLocationsController(AppDbContext context, IItemLocationRepository itemLocationRepository, IMapper mapper )
        {
            _context = context;
            _itemLocationRepository = itemLocationRepository;
            this.mapper = mapper;
        }

        
        [HttpGet("Locations")]
        public async Task<ActionResult<IEnumerable<ItemLocation>>> GetItemLocations()
        {
            var GetItemLocations = await _itemLocationRepository.GetItemLocations();

            return Ok(GetItemLocations);
        }

        
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

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemLocation(int id,[FromBody] ItemLocationDto itemLocation)
        {
            if (itemLocation ==null)
            {
                return BadRequest();
            }



            try
            {
               var item = await _itemLocationRepository.PutItemLocation(id, itemLocation);
                if (item == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(item);
                }
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

        }

       
        [HttpPost("Location/post")]
        public async Task<ActionResult<ItemLocation>> PostItemLocation([FromBody] ItemLocationDto itemLocation)
        {
            var map = mapper.Map<ItemLocation>(itemLocation);
          var post =  await _itemLocationRepository.PostItemLocation(map);

            return Ok(post);
        }

       
        [HttpDelete("del/{id}")]
        public async Task<ActionResult<ItemLocation>> DeleteItemLocation(int id)
        {
           
           var item = await _itemLocationRepository.DeleteItemLocation(id);

            if (item == null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        private bool ItemLocationExists(int id)
        {
            return _context.ItemLocations.Any(e => e.Id == id);
        }
    }
}
