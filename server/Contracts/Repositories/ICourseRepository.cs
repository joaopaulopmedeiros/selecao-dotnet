using System.Threading.Tasks;

using App.Models;

namespace App.Contracts.Repositories
{
    public interface ICourseRepository 
    {
        Task<dynamic> ListAll();
        Task<dynamic> Add(Course model);
    }
}
