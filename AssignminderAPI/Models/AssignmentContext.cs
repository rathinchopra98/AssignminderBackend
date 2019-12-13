using Microsoft.EntityFrameworkCore;

namespace AssignminderAPI.Models
{
    public class AssignmentContext : DbContext
    {
        public AssignmentContext(string connectionString)
            : base(GetOptions(connectionString))
        {

        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public DbSet<Assignment> Assignments { get; set; }
    }

}