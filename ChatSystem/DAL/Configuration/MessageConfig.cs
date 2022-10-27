using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class MessageConfig : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(m => m.MessageID);

        builder.Property(m => m.ChatID)
            .IsRequired();

        builder.Property(m => m.SenderID)
            .IsRequired();

        builder.Property(m => m.RecieverID)
            .IsRequired();

        builder.Property(m => m.MessageBody)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(m => m.Created)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder.Property(m => m.Checked)
            .IsRequired()
            .HasDefaultValue(0);

        builder.HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatID);
    }
}