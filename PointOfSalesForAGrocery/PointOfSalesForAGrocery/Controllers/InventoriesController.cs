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

        
        [HttpGet("Inventories")]
        public IActionResult GetInventories()
        { 
            var GetInventories =   _context.Inventories.ToList();

            return Ok(GetInventories);
        }

        
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

        
        [HttpPost("post")]
        public async Task<ActionResult<Inventory>> PostInventory([FromBody] InventoryDto c)
        {
           
            var finalitem = mapper.Map<Inventory>(c);
            var post = await _inventoryRepository.PostInventory(finalitem);

            if (post != null)
            {
                return Ok(post);
            }
            else
            {
                return BadRequest();
            }

            

            
        }

        
        [HttpDelete("Delet/{id}")]
        public async Task<ActionResult<Inventory>> DeleteInventory(int id)
        {

           await _inventoryRepository.RemoveInventory(id);
            
            
           return Ok();
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventories.Any(e => e.Id == id);
        }
    }
}
