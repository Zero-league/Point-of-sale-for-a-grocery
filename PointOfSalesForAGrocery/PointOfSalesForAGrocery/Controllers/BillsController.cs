﻿using System;
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
    [Route("api/bills")]
    public class BillsController : Controller
    {
        private readonly AppDbContext _context;

        public BillsController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            return await _context.Bill.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBillById(int id)
        {
            var bill = await _context.Bill.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBill(int id, Bill bill)
        {
            if (id != bill.Id)
            {
                return BadRequest();
            }

            _context.Entry(bill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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

       
        [HttpPost]
        public async Task<ActionResult<Bill>> AddBill([FromBody] Bill bill)
        {
            try
            {
                if (bill.Discount != 0)
                {
                    Bill bill1 = new Bill();
                    bill1.Amount = bill.Amount * (bill.Discount / 100);
                    bill1.DateTime = bill.DateTime;
                    bill1.Discount = bill.Discount;
                    bill1.SalesPerson = bill.SalesPerson;

                    _context.Bill.Add(bill1);
                    await _context.SaveChangesAsync();
                    return Ok(bill1);
                }
                else
                {
                    Bill b = new Bill();
                    b.Amount = bill.Amount;
                    b.DateTime = bill.DateTime;
                    b.Discount = bill.Discount;
                    b.SalesPerson = bill.SalesPerson;

                    _context.Bill.Add(bill);
                    await _context.SaveChangesAsync();
                    return Ok(b);
                }

                
            }
            catch (Exception)
            {

                return BadRequest();
            }
           


            
        }

      
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bill>> DeleteBill(int id)
        {
            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            _context.Bill.Remove(bill);
            await _context.SaveChangesAsync();

            return bill;
        }

        private bool BillExists(int id)
        {
            return _context.Bill.Any(e => e.Id == id);
        }
    }
}
