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
    [Route("api")]
    public class UnitmesurementsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUnitMesurementRepositorys unitMesurementRepository;

        public UnitmesurementsController(AppDbContext context, IUnitMesurementRepositorys unitMesurementRepository )
        {
            _context = context;
            this.unitMesurementRepository = unitMesurementRepository;
        }

        
        [HttpGet("Unitmesurements")]
        public async Task<ActionResult<IEnumerable<Unitmesurement>>> GetUnitmesurements()
        {
           var get =  await unitMesurementRepository.GetUnitmesurements();
            return Ok(get);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Unitmesurement>> GetUnitmesurement(int id)
        {
            var unitmesurement = await unitMesurementRepository.GetUnitmesurement(id);

            if (unitmesurement == null)
            {
                return NotFound();
            }

            return unitmesurement;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitmesurement(int id, [FromBody] UnitmesurementDto unitmesurementDto)
        {
            if (unitmesurementDto == null)
            {
                return BadRequest();
            }

            
              var um =  await unitMesurementRepository.PutUnitmesurement(id, unitmesurementDto);
            if (um == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(um);
            }

            
        }

       
        [HttpPost]
        public async Task<ActionResult<Unitmesurement>> PostUnitmesurement([FromBody] UnitmesurementDto unitmesurementDto)
        {
           
          var post =  await unitMesurementRepository.PostUnitmesurement(unitmesurementDto);

            return Ok(post);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unitmesurement>> DeleteUnitmesurement(int id)
        {
            
            
           var item = await unitMesurementRepository.DeleteUnitmesurement(id);
            if (item == null)
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
