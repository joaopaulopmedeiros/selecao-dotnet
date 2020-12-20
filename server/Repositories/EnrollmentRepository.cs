using System.Threading.Tasks;
using System.Linq;

using App.Data;
using App.Models;
using App.Contracts.Repositories;

namespace App.Repositories
{
    public class EnrollmentRepository : BaseRepository, IEnrollmentRepository
    {
        protected DataContext context;

        public EnrollmentRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<dynamic> Add(Enrollment model)
        {
            this.context.Enrollments.Add(model);
            return await this.context.SaveChangesAsync();
        }
    }
}
