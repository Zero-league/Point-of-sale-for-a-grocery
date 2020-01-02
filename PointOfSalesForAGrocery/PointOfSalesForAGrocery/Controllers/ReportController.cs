using Microsoft.AspNetCore.Mvc;
using POS.DataSource;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext Context;

        public ReportController(AppDbContext appDbContext)
        {
            this.Context = appDbContext;
        }

        [HttpGet("Report")]
        public List<Bill> GetReport(DateTime StartDate, DateTime EndDate)
        {
            var report = (from m in Context.Bill.Where(d => d.DateTime >= StartDate && d.DateTime <= EndDate)
                         select m).ToList();

            return report;
        }
    }
}
