using App.Models;

namespace App.Contracts.Services
{
    public interface ITokenService 
    {
         string GenerateToken(User user);
    }
}