using System.Threading.Tasks;
using System.Linq;

using App.Data;
using App.Models;
using App.Contracts.Repositories;

namespace App.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        protected DataContext context;

        public UserRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<dynamic> Add(User model)
        {
            this.context.Users.Add(model);
            return await this.context.SaveChangesAsync();
        }
    }
}
