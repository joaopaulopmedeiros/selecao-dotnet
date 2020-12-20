using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Models;
using System.Linq;
using App.Repositories;

namespace App.Controllers
{
    [Route("enrollments")]

    public class EnrollmentController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Enrollment>>> Get([FromServices] EnrollmentRepository enrollmentRepository)
        {
            var Enrollments = await enrollmentRepository.ListAll();
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
                await enrollmentRepository.Add(model);
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
