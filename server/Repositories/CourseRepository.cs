using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Models;
using App.Contracts.Repositories;

namespace App.Repositories
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        protected DataContext context;

        public CourseRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<dynamic> ListAll()
        {
            return await this.context.Courses.ToListAsync();
        }
        public async Task<dynamic> Add(Course model)
        {
            this.context.Courses.Add(model);
            return await this.context.SaveChangesAsync();
        }
    }
}
