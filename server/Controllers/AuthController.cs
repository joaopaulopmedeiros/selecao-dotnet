using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using App.Services;
using App.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using App.Helpers;
using App.Repositories;

namespace App.Controllers
{
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] AuthService authService,
            [FromServices] TokenService tokenService,
            [FromBody] User model
        )
        {
            User user = await authService.Attempt(model.Email, model.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha incorretos" });
            }

            var token = tokenService.GenerateToken(user);

            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> Post(
            [FromServices] UserRepository userRepository,
            [FromBody] User model
        )
        {
            if (ModelState.IsValid)
            {
                model.Password = Hash.Make(model.Password);
                await userRepository.Add(model);
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public async Task<ActionResult<User>> Authenticated([FromServices] AuthService authService)
        {
            User user = await authService.getAuthUser(User.Identity.Name);
            return user;
        }
    }
}
