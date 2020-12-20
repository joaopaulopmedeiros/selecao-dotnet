using System.Threading.Tasks;

using App.Models;

namespace App.Contracts.Repositories
{
    public interface IUserRepository 
    {
        Task<dynamic> Add(User model);
    }
}
