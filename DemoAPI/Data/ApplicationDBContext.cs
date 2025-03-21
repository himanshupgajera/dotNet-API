using DemoAPI;
using Microsoft.EntityFrameworkCore;

namespace customer.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> student { get; set; }
    }
}