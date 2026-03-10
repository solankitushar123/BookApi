using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApi.Persistence.Configurations;

public sealed class IssueBookEntityConfiguration : IEntityTypeConfiguration<BookIssue>
{
    public void Configure(EntityTypeBuilder<BookIssue> builder)
    {
        builder.ToTable("BookIssue");

       
        builder.HasKey(x => x.IssueId);

       
        builder.HasOne(i => i.Member)
            .WithMany(u => u.BookIssues)
            .HasForeignKey(i => i.MemberId)
            .OnDelete(DeleteBehavior.Restrict);

       
        builder.HasOne(i => i.Book)
            .WithMany(b => b.BookIssues)
            .HasForeignKey(i => i.BookId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}