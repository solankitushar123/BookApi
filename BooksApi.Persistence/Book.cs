namespace BooksApi.Persistence;

public class Book
{
    public int BookId { get; set; }
    public string BookName { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string? Publishers { get; set; } 
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<BookIssue> BookIssues { get; set; } = new List<BookIssue>();
}