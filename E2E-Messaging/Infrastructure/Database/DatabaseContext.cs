using Infrastructure.Database.Configurations.Messages;
using Infrastructure.Database.Configurations.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public sealed class E2EMessagingDatabaseContext : IdentityDbContext
    {
        public E2EMessagingDatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());

            base.OnModelCreating(modelBuilder);

            var roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
