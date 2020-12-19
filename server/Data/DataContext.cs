using Microsoft.EntityFrameworkCore;
using App.Entities;

namespace App.Data 
{
    public class DataContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasKey(x => new { x.UserId, x.CourseId });
        }
    }
}