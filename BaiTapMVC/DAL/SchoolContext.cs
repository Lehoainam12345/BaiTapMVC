using System.Data.Entity;
using BaiTapMVC.Models;

namespace BaiTapMVC.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassSection> ClassSections { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}