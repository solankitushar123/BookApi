using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApi.Persistence.Configurations;

public sealed class BookEntityConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {

        builder.HasKey(b => b.BookId);

        builder.Property(b => b.BookName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(b => b.Author)
            .HasMaxLength(50);

        builder.HasOne(book => book.Category)
            .WithMany(category => category.Book)
            .HasForeignKey(book => book.CategoryId);
    }
}