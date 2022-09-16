using Company.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        // Mapping Entities (Models)
        public DbSet<User> User { get; set; }
        public DbSet<Game> Game { get; set; }
    }
}
