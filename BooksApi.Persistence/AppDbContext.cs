using Microsoft.EntityFrameworkCore;

namespace BooksApi.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Category { get; init; }
    public DbSet<Member> Member { get; init; }
    public DbSet<Book> Book { get; init; }
    public DbSet<BookIssue> BookIssue { get; init; }

    // AppDbContext.cs
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        Type t = typeof(AppDbContext);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    base.OnModelCreating(modelBuilder);
}
}