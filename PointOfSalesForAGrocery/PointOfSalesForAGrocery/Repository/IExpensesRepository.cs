using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Repository
{
    public interface IExpensesRepository
    {
        //Get all Expenses
        ICollection <Expenses> GetAllExpenses();

        //Get a City
        Expenses GetExpenseByID(int ID);

        //Add a Expense
        void AddExpense(Expenses expensesObject);

        //Edit a city
        int UpdateExpense(int ID, Expenses ExpensesObject);

        //Delete a City
        void DeleteExpense(int ID);

    }
}
