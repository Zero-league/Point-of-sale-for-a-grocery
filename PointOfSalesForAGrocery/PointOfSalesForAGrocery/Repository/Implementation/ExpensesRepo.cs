using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS.DataSource;
using POS.Models;

namespace PointOfSalesForAGrocery.Repository.Implementation
{
    public class ExpensesRepo : IExpensesRepository
    {
        private readonly AppDbContext _appDbContext;

        public ExpensesRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddExpense(POS.Models.Expenses expensesObject)
        {
            _appDbContext.Expenses.Add(expensesObject);
            _appDbContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public void DeleteExpense(int ID)
        {
            var expense = _appDbContext.Expenses.Where(c => c.ExpId == ID).FirstOrDefault();
            _appDbContext.Expenses.Remove(expense);
            _appDbContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public ICollection<Expenses> GetAllExpenses()
        {
            var expense = _appDbContext.Expenses.ToList();
            return expense;
            //throw new NotImplementedException();
        }

        public POS.Models.Expenses GetExpenseByID(int ID)
        {
            var expenses = _appDbContext.Expenses.Where(c => c.ExpId == ID).SingleOrDefault();
            return expenses;
            //throw new NotImplementedException();
        }

        public int UpdateExpense(int ID, POS.Models.Expenses ExpensesObject)
        {
            var expense = _appDbContext.Expenses.Where(c => c.ExpId == ID).SingleOrDefault();

            if(expense == null)
            {
                return 0;
            }
            else
            {
                expense.Date = ExpensesObject.Date;
                expense.Payment = ExpensesObject.Payment;
                _appDbContext.SaveChanges();
                return 1;

            }
            //throw new NotImplementedException();
        }
    }
}
