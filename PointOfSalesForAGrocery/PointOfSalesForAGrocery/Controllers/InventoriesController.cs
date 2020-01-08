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

        public InventoriesController(AppDbContext context, IInventoryRepository inventoryRepository)
        {
            _context = context;
            this._inventoryRepository = inventoryRepository;
        }


        [HttpGet("Inventories")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetInventories()
        {
            var GetInventories = await _inventoryRepository.GetInventories();

            return Ok(GetInventories);
        }


        [HttpGet("Inventories/{id}")]
        public async Task<ActionResult<ItemDto>> GetInventory(int id)
        {
            var Item = await _inventoryRepository.GetInventory(id);

            if (Item == null)
            {
                return NotFound();
            }

            return Ok(Item);
        }


        [HttpPut("Put/{ID}")]
        public async Task<IActionResult> PutInventory(string ID, [FromBody] InventoryDto inventoryDto)
        {
            int id = int.Parse(ID);
            if (inventoryDto == null)
            {
                return BadRequest();
            }

            try
            {
                var update = await _inventoryRepository.UpdateInventory(id, inventoryDto);
                if (update != null)
                {
                    return Ok(update);
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
        public async Task<ActionResult<Inventory>> PostInventory([FromBody] InventoryDto inventoryDto)
        {
            if (inventoryDto == null)
            {
                return BadRequest();
            }
            Inventory inventory = new Inventory();
            if (ModelState.IsValid)
            {
                inventory = await _inventoryRepository.PostInventory(inventoryDto);
            }
            if (inventory != null)
            {
                return Ok(inventory);
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpDelete("Delet/{id}")]
        public async Task<ActionResult<Inventory>> DeleteInventory(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _inventoryRepository.RemoveInventory(id);


            return Ok();
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventories.Any(e => e.Id == id);
        }


    }
}