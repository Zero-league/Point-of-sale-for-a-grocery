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

namespace PointOfSalesForAGrocery.Controllers
{
    [Route("api/bills")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBillRepository _billRepository;

        public BillsController(AppDbContext context, IBillRepository billRepository)
        {
            _context = context;
            this._billRepository = billRepository;
        }

        [HttpGet]
        public IActionResult GetBills()
        {
            var bills = _context.Bill.ToList();

            return Ok(bills);
        }

        [HttpGet("{id}")]
        public IActionResult GetBillById(int id)
        {
            var bill = _billRepository.GetBillById(id);

            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBill(int id, [FromBody] Bill bill)
        {
            if (bill == null)
            {
                return BadRequest();
            }

            try
            {
                var update =  _billRepository.UpdateBill(id, bill);
                if(update != null)
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult AddBill([FromBody]Bill bill)
        {
            var newbill = _billRepository.AddBill(bill);

            if(newbill != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBill(int id)
        {
            var bill = _billRepository.DeleteBill(id);
            if (bill == null)
            {
                return BadRequest();
            }

            return Ok();

            
        }

        
    }
}
