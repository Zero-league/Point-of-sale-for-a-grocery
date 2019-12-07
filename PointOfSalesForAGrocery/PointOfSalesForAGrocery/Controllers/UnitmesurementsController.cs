using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.DataSource;
using POS.Models;

namespace PointOfSalesForAGrocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitmesurementsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UnitmesurementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Unitmesurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unitmesurement>>> GetUnitmesurements()
        {
            return await _context.Unitmesurements.ToListAsync();
        }

        // GET: api/Unitmesurements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Unitmesurement>> GetUnitmesurement(int id)
        {
            var unitmesurement = await _context.Unitmesurements.FindAsync(id);

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
        public async Task<IActionResult> PutUnitmesurement(int id, Unitmesurement unitmesurement)
        {
            if (id != unitmesurement.Id)
            {
                return BadRequest();
            }

            _context.Entry(unitmesurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitmesurementExists(id))
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

        // POST: api/Unitmesurements
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Unitmesurement>> PostUnitmesurement(Unitmesurement unitmesurement)
        {
            _context.Unitmesurements.Add(unitmesurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnitmesurement", new { id = unitmesurement.Id }, unitmesurement);
        }

        // DELETE: api/Unitmesurements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unitmesurement>> DeleteUnitmesurement(int id)
        {
            var unitmesurement = await _context.Unitmesurements.FindAsync(id);
            if (unitmesurement == null)
            {
                return NotFound();
            }

            _context.Unitmesurements.Remove(unitmesurement);
            await _context.SaveChangesAsync();

            return unitmesurement;
        }

        private bool UnitmesurementExists(int id)
        {
            return _context.Unitmesurements.Any(e => e.Id == id);
        }
    }
}
