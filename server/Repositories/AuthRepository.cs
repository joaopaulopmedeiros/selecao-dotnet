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

namespace App.Repositories
{
    public class AuthRepository
    {
        protected DataContext authRepository;

        public AuthRepository(DataContext context)
        {
            this.authRepository = context;
        }

        [Authorize]
        public async Task<User> getAuthUser(string email)
        {
            return await (from u in this.authRepository.Users
                          where u.Email == email
                          select u).FirstOrDefaultAsync();
        }
        /* 
await (from u in context.Users
               where u.Email == User.Identity.Name
               select u).FirstOrDefaultAsync();
*/
    }
}