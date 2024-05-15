using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Users
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(e => e.UserName).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.PasswordHash).IsRequired();
            builder.Property(e => e.PublicPgpKey).IsRequired();
            builder.Property(e => e.PrivatePgpKey).IsRequired();
        }
    }
}
