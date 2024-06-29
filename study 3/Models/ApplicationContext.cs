using Microsoft.EntityFrameworkCore;
namespace study_3.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
