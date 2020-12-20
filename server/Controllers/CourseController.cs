using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Models;
using App.Repositories;

namespace App.Controllers
{
    [Route("courses")]

    public class CourseController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Course>>> Get([FromServices] CourseRepository courseRepository)
        {
            var courses = await courseRepository.ListAll();
            return courses;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Course>> Store(
            [FromServices] CourseRepository courseRepository,
            [FromBody] Course model
        )
        {
            if (ModelState.IsValid)
            {
                await courseRepository.Add(model);
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
