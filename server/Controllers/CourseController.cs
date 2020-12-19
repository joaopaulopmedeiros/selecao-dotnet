using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Entities;

namespace App.Controllers
{
    [Route("courses")]

    public class CourseController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Course>>> Get([FromServices] DataContext context)
        {
            var courses = await context.Courses.ToListAsync();
            return courses;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Course>> Store(
            [FromServices] DataContext context,
            [FromBody] Course model
        )
        {
            if (ModelState.IsValid)
            {
                context.Courses.Add(model);
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
