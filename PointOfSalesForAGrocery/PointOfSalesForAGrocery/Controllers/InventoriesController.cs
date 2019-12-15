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
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper mapper;

        public InventoriesController(AppDbContext context, IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _context = context;
            this._inventoryRepository = inventoryRepository;
            this.mapper = mapper;
        }

        // GET: api/Inventories
        [HttpGet("Inventories")]
        public IActionResult GetInventories()
        { 
            var GetInventories =   _context.Inventories.ToList();

            return Ok(GetInventories);
        }

        // GET: api/Inventories/5
        [HttpGet("Inventories/{id}")]
        public async Task<ActionResult<ItemDto>> GetInventory(int id )
        {
            var Item = await _inventoryRepository.GetInventory(id);

            if (Item == null)
            {
                return NotFound();
            }

            return Ok(Item);
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> PutInventory(int id, [FromBody] InventoryDto inventoryDto)
        {
            if (inventoryDto == null)
            {
                return BadRequest();
            }
            
            try
            {
               var update = await _inventoryRepository.UpdateInventory(id, inventoryDto);
                if (update != null)
                {
                    return Ok();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/Inventories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post")]
        public async Task<ActionResult<Inventory>> PostInventory([FromBody] InventoryDto c)
        {
           
            var finalitem = mapper.Map<Inventory>(c);
            var post = await _inventoryRepository.PostInventory(finalitem);

            if (post != null)
            {
                return CreatedAtAction("GetInventory", new { id = post.Id }, post);
            }
            else
            {
                return BadRequest();
            }

            

            
        }

        // DELETE: api/Inventories/5
        [HttpDelete("Delet/{id}")]
        public async Task<ActionResult<Inventory>> DeleteInventory(int id)
        {

           var delete =  await _inventoryRepository.RemoveInventory(id);
            if (delete == null)
            {
                return BadRequest();
            }
            
            return Ok();
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventories.Any(e => e.Id == id);
        }
    }
}
