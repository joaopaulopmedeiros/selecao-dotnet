using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Models;
using System.Linq;

namespace App.Controllers
{
    [Route("payments")]

    public class PaymentController : ControllerBase
    {

        public async Task<ActionResult<List<Payment>>> Get([FromServices] DataContext context)
        {
            var payments = await context.Payments.ToListAsync();
            return payments;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Payment>> Store(
            [FromServices] DataContext context,
            [FromBody] Payment model
        )
        {
            if (ModelState.IsValid)
            {
                context.Payments.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
