using Microsoft.EntityFrameworkCore;

namespace AssignminderAPI.Models
{
    public class AssignmentContext : DbContext
    {
        public AssignmentContext(DbContextOptions<AssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment> TodoItems { get; set; }
    }
}