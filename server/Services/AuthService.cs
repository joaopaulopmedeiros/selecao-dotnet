using System.Threading.Tasks;
using App.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using App.Data;
using App.Contracts.Services;


namespace App.Services
{
    public class AuthService : IAuthService
    {
        protected DataContext authRepository;

        public AuthService(DataContext context)
        {
            this.authRepository = context;
        }

        public async Task<dynamic> Attempt(string email, string password)
        {
            return await (from u in this.authRepository.Users
                          where u.Email == email && u.Password == Hash.Make(password)
                          select u).FirstOrDefaultAsync();
        }

        [Authorize]
        public async Task<dynamic> getAuthUser(string email)
        {
            return await (from u in this.authRepository.Users
                          where u.Email == email
                          select u).FirstOrDefaultAsync();
        }
    }
}
