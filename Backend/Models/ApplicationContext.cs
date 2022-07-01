using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Replacement> Replacements { get; set; }
        public DbSet<UserString> UserStrings { get; set; }
    }
}
