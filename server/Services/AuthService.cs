using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using App.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Services
{
    public class AuthService
    {
        protected DataContext authRepository;

        public AuthService(DataContext context)
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
    }
}
