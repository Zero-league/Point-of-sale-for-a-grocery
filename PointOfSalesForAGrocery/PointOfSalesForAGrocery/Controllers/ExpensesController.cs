using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSalesForAGrocery.Repository;
using POS.Models;

namespace PointOfSalesForAGrocery.Controllers
{
    [Route("api/expense")]
    public class ExpensesController : Controller
    {
        IExpensesRepository _ExpensesRepo;

        public ExpensesController(IExpensesRepository expenses)
        {
            this._ExpensesRepo = expenses;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var expenses = _ExpensesRepo.GetAllExpenses();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public IActionResult GetExpenseByID(int id)
        {
            if (id < 0)
            {
                BadRequest();
            }
            var expense = _ExpensesRepo.GetExpenseByID(id);
            return Ok(expense);
        }

        [HttpPost]
        public IActionResult CreateExpense([FromBody] Expenses NewObj)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            if(NewObj == null)
            {
                BadRequest();
            }
            _ExpensesRepo.AddExpense(NewObj);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] Expenses NewObj)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            int result = _ExpensesRepo.UpdateExpense(id, NewObj);
            if(result == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExpenses(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            _ExpensesRepo.DeleteExpense(id);
            return Ok();
        }
      
    }
}