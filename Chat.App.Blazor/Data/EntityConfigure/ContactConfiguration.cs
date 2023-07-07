using Chat.App.Blazor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.App.Blazor.Data.EntityConfigure;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasOne(c => c.User)
             .WithMany(u => u.Contacts)
             .HasForeignKey(c => c.UserId)
             .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Friend)
            .WithMany()
            .HasForeignKey(c => c.FriendId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
