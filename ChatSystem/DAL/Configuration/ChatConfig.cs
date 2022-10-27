using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class ChatConfig : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(c => c.ChatID);

        builder.Property(c => c.UserID)
            .IsRequired();

        builder.Property(c => c.RecieverID)
            .IsRequired();
            
        builder.Property(c => c.Created)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder.HasOne(c => c.User)
            .WithMany(u => u.Chat)
            .HasForeignKey(c => c.UserID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(a => a.ChatID).OnDelete(DeleteBehavior.NoAction);
    }
}