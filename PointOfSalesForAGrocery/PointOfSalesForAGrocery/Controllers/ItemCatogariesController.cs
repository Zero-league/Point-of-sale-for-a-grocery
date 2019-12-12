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
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCatogariesController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IItemCatogaryRepository _itemCatogaryRepository;
        private readonly IMapper mapper;

        public ItemCatogariesController(AppDbContext context, IItemCatogaryRepository itemCatogaryRepository, IMapper mapper)
        {
            _context = context;
            _itemCatogaryRepository = itemCatogaryRepository;
            this.mapper = mapper;
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

            
               var item =  await _itemCatogaryRepository.UpdatetemCatogary(id, itemCatogaryDto);

                if (item == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(item);
                }
           

           
        }

        // POST: api/ItemCatogaries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ItemCatogary>> PostItemCatogary([FromBody] ItemCatogaryDto itemCatogaryDto)
        {
            var map = mapper.Map<ItemCatogary>(itemCatogaryDto);   
          var post =  await _itemCatogaryRepository.PostItemCatogary(map);

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
            if (delete  != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        private bool ItemCatogaryExists(int id)
        {
            return _context.ItemCatogaries.Any(e => e.Id == id);
        }
    }
}
