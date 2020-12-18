using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using App.Services;
using App.Repositories;

namespace App.Controllers 
{
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.Email, model.Password);

            if (user == null) {
                return NotFound(new { message = "Usuário ou senha incorretos" });
            } 

            var token = TokenService.GenerateToken(user);
            
            return new {
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
