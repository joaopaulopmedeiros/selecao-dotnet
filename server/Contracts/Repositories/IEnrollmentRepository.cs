using System.Threading.Tasks;

using App.Resources;

namespace App.Contracts.Repositories
{
    public interface IEnrollmentRepository 
    {
        Task<dynamic> Add(EnrollmentRequest model);
    }
}
