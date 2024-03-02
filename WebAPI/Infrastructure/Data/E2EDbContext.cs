using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Messages;
using WebAPI.Domain.Users;

namespace WebAPI.Infrastructure.Data
{
    public class E2EDbContext : IdentityDbContext<User>
    {

        public E2EDbContext(DbContextOptions<E2EDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

    }
}
