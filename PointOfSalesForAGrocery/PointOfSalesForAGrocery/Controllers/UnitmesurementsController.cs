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
    public class UnitmesurementsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUnitMesurementRepositorys unitMesurementRepository;

        public UnitmesurementsController(AppDbContext context, IUnitMesurementRepositorys unitMesurementRepository )
        {
            _context = context;
            this.unitMesurementRepository = unitMesurementRepository;
        }

        // GET: api/Unitmesurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unitmesurement>>> GetUnitmesurements()
        {
           var get =  await unitMesurementRepository.GetUnitmesurements();
            return Ok(get);
        }

        // GET: api/Unitmesurements/5
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

        // PUT: api/Unitmesurements/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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

        // POST: api/Unitmesurements
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Unitmesurement>> PostUnitmesurement([FromBody] UnitmesurementDto unitmesurementDto)
        {
           
          var post =  await unitMesurementRepository.PostUnitmesurement(unitmesurementDto);

            return CreatedAtAction("GetUnitmesurement", new { id = post.Id }, unitmesurementDto);
        }

        // DELETE: api/Unitmesurements/5
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

        private bool UnitmesurementExists(int id)
        {
            return _context.Unitmesurements.Any(e => e.Id == id);
        }
    }
}
