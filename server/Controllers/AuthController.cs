using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using App.Services;
using App.Repositories;
using App.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Controllers
{
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] DataContext context,
            [FromBody] User model
        )
        {
            User user = await (from u in context.Users
                              where u.Email == model.Email && u.Password == model.Password
                              select u).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha incorretos" });
            }

            var token = TokenService.GenerateToken(user);

            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Authenticated - {0}", User.Identity.Name);
    }
}
