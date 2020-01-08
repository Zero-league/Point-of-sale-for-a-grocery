using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.DataSource;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Controllers
{
    [Route("report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly AppDbContext Context;

        public ReportController(AppDbContext appDbContext)
        {
            this.Context = appDbContext;
        }

        [HttpPost("post")]
        public async Task<ActionResult<IEnumerable<Bill>>> GetReport([FromBody] string sd,string ed)
        {
            string sdate = (DateTime.Parse(sd)).ToShortTimeString();
            string edate = (DateTime.Parse(ed)).ToShortTimeString();
            var report = await (from m in Context.Bill.Where(d => d.DateTime >= DateTime.Parse(sdate) && d.DateTime <= DateTime.Parse(edate))
                         select m).ToListAsync();

            return Ok(report);
        }
    }
}
