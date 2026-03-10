using System.ComponentModel.DataAnnotations;
namespace BooksApi.Persistence;

public class Category
{
    public int CategoryId { get; set; }

    public required string CategoryName { get; set; }

    public ICollection<Book> Book { get; set; } = [];
}