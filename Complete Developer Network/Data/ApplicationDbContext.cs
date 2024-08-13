using Complete_Developer_Network.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Complete_Developer_Network.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users  { get; set; }
    }
}
