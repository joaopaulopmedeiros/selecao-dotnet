using System.Threading.Tasks;

namespace App.Contracts.Services
{
    public interface IAuthService
    {
        Task<dynamic> Attempt(string email, string password);
        Task<dynamic> getAuthUser(string email);
    }
}
