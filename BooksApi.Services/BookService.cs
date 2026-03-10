using BooksApi.core.Dtos;
using BooksApi.Core.Requests;
using BooksApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Services;

public sealed class BookService
{
    private readonly AppDbContext _dbContext;

    public BookService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IEnumerable<BookDto> GetAll() => _dbContext.Book
            .Select(book => new BookDto(book.BookId, book.BookName, book.Author,book.Publishers ,book.CategoryId))
            .ToList();
    public BookDto Create(CreateBookRequest request)
    {
        var book = new Book
        {
            BookName = request.BookName,
            Author = request.Author,
            Publishers = request.Publishers,
            CategoryId = request.CategoryId
        };

        _dbContext.Book.Add(book);
        _dbContext.SaveChanges();
        return new BookDto(book.BookId, book.BookName, book.Author,book.Publishers, book.CategoryId);
    }
}