using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Messages;
using WebAPI.Domain.Users;

namespace WebAPI.Infrastructure.Data
{
    public class E2EDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Connectionstring");
        }

    }
}
