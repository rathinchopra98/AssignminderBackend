using Microsoft.EntityFrameworkCore;

namespace AssignminderAPI.Models
{
    public class CourseContext : DbContext
    {
        public CourseContext(string connectionString)
            : base(GetOptions(connectionString))
        {

        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public DbSet<Course> Courses { get; set; }
    }

}