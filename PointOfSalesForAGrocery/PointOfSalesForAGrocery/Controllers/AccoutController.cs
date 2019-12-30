using Microsoft.AspNetCore.Mvc;
using PosAuth.Areas.Identity.Pages.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSalesForAGrocery.Controllers
{
    [ApiController]
    [Route("log")]
    public class AccoutController : ControllerBase
    {
        private readonly RegisterModel registerModel;

        public AccoutController(RegisterModel registerModel)
        {
            this.registerModel = registerModel;
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> post([FromBody] RegisterModel registerModel)
        {
           var post =await  registerModel.OnPostAsync();

            return post;
        }
    }
}
