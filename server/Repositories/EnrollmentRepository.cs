using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using App.Data;
using App.Models;
using App.Contracts.Repositories;
using App.Resources;

namespace App.Repositories
{
    public class EnrollmentRepository : BaseRepository, IEnrollmentRepository
    {
        protected DataContext context;

        public EnrollmentRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<dynamic> ListAll()
        {
            return await this.context.Enrollments.ToListAsync();
        }

        public async Task<dynamic> Add(EnrollmentRequest model)
        {
            if (model.UserId == 0 || model.CourseId == 0)
            {
                return null;
            }

            var user = await (from u in this.context.Users
                              where u.Id == model.UserId
                              select u).FirstOrDefaultAsync();

            var course = await (from u in this.context.Courses
                                where u.Id == model.CourseId
                                select u).FirstOrDefaultAsync(); ;

            if(user == null || course == null) 
            {
                return null;
            }

            Enrollment enrollment = new Enrollment { User = user, Course = course };

            return enrollment;

            //this.context.Enrollments.Add(enrollment);
            //return await this.context.SaveChangesAsync();
        }
    }
}
