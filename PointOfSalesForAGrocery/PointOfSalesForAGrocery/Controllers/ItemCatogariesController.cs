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
using POS.Models.Entities;

namespace PointOfSalesForAGrocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCatogariesController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IItemCatogaryRepository _itemCatogaryRepository;
        public ItemCatogariesController(AppDbContext context, IItemCatogaryRepository itemCatogaryRepository)
        {
            _context = context;
            _itemCatogaryRepository = itemCatogaryRepository;
        }

        // GET: api/ItemCatogaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCatogary>>> GetItemCatogaries()
        {
            var ItemCatogaries =  await _itemCatogaryRepository.GetItemCatogaries();

            return Ok(ItemCatogaries);
        }

        // GET: api/ItemCatogaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCatogary>> GetItemCatogary(int id)
        {
            var itemCatogary = await _itemCatogaryRepository.GetItemCatogary(id);

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
        public async Task<IActionResult> PutItemCatogary(int id, [FromBody] ItemCatogaryDto itemCatogaryDto)
        {
            if (itemCatogaryDto == null)
            {
                return BadRequest();
            }

            

            try
            {
                await _itemCatogaryRepository.UpdatetemCatogary(id);
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
        public async Task<ActionResult<ItemCatogary>> PostItemCatogary([FromBody] ItemCatogaryDto itemCatogaryDto)
        {
          var post =  await _itemCatogaryRepository.PostItemCatogary(itemCatogaryDto);

            return CreatedAtAction("GetItemCatogary", new { id = post.Id }, post);
        }

        // DELETE: api/ItemCatogaries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemCatogary>> DeleteItemCatogary(int id)
        {
            var itemCatogary = await _itemCatogaryRepository.GetItemCatogary(id);
            if (itemCatogary == null)
            {
                return NotFound();
            }

            var delete = await _itemCatogaryRepository.DeleteItemCatogary(id);


            return delete;
        }

        private bool ItemCatogaryExists(int id)
        {
            return _context.ItemCatogaries.Any(e => e.Id == id);
        }
    }
}
