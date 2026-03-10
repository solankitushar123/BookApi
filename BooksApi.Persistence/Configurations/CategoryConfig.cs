using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApi.Persistence.Configurations;

public sealed class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.HasKey(b => b.CategoryId);

        builder.Property(b => b.CategoryName)
            .HasMaxLength(50)
            .IsRequired();
    }
}