using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Models;
using System.Linq;
using App.Repositories;
using App.Resources;

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
        public async Task<ActionResult<dynamic>> Post(
            [FromServices] EnrollmentRepository enrollmentRepository,
            [FromBody] EnrollmentRequest model
        )
        {
            if (ModelState.IsValid)
            {
                var enrollment = await enrollmentRepository.Add(model);
                
                if(enrollment == null) return BadRequest(new { message = "Usuário ou curso estão incorretos" });
                
                return enrollment;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
