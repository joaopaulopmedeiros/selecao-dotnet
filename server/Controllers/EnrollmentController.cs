using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Models;
using System.Linq;

namespace App.Controllers
{
    [Route("enrollments")]

    public class EnrollmentController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Enrollment>>> Get([FromServices] DataContext context)
        {
            var Enrollments = await context.Enrollments.ToListAsync();
            return Enrollments;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Enrollment>> Store(
            [FromServices] EnrollmentRepository enrollmentRepository,
            [FromBody] Enrollment model
        )
        {
            if (ModelState.IsValid)
            {
                await enrollmentRepository.add(model);
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
