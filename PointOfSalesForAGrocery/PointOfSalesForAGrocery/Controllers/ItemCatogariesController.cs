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
    public class ItemCatogariesController : Controller
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

      
        [HttpGet("Catagaries")]
        public async Task<ActionResult<IEnumerable<ItemCatogary>>> GetItemCatogaries()
        {
            var ItemCatogaries =  await _itemCatogaryRepository.GetItemCatogaries();

            return Ok(ItemCatogaries);
        }

        
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

        
        [HttpPost("cat/post")]
        public async Task<ActionResult<ItemCatogary>> PostItemCatogary([FromBody] ItemCatogaryDto itemCatogaryDto)
        {
            var map = mapper.Map<ItemCatogary>(itemCatogaryDto);   
          var post =  await _itemCatogaryRepository.PostItemCatogary(map);

            return Ok(post);
        }

        
        [HttpDelete("DeleteCat/{id}")]
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

        
    }
}
