using System.Threading.Tasks;

using App.Models;

namespace App.Contracts.Repositories
{
    public interface IEnrollmentRepository 
    {
        Task<dynamic> Add(Enrollment model);
    }
}
