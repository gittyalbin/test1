using Microsoft.EntityFrameworkCore;

namespace test2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Test> Test { get; set; }


    }
}
