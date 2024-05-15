using Domain.Models.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Messages
{
    internal sealed class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Content).IsRequired();
            builder.Property(e => e.SentAt).IsRequired();
            builder.HasOne(message => message.Sender).WithMany(appUser => appUser!.SentMessages).IsRequired();
            builder.HasOne(message => message.Receiver).WithMany(appUser => appUser!.ReceivedMessages).IsRequired();
        }
    }
}
