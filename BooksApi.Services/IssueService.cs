using BooksApi.core.Requests;
using BooksApi.Core.Dtos;
using BooksApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;


namespace LibraryApi.Services;

public sealed class IssueBookservice
{
    private readonly AppDbContext _context;
    private readonly ILogger<IssueBookservice> _logger;
    public IssueBookservice(AppDbContext context, ILogger<IssueBookservice> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger;
    }
    public IEnumerable<BookIssueDto> GetIssuedBook(string? name = null)
    {
        IQueryable<BookIssue> query = _context.BookIssue.AsQueryable();
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(u => u.Member.MemberName.Contains(name));
        }
        IList<BookIssueDto> books = query
                                    .Include(i => i.Book)
                                    .Include(i => i.Member)

                                    .Select(i => new BookIssueDto(
                                                                   i.IssueId,              
                                                                   i.Member.MemberName,    
                                                                   i.Book.BookId,         
                                                                   i.Book.BookName,        
                                                                   i.Member.MemberId,      
                                                                   i.IssueDate,            
                                                                   i.ReturnDate,
                                                                   i.RenewDate ?? i.IssueDate.AddDays(20)))
                                    .ToArray();
        return new ReadOnlyCollection<BookIssueDto>(books);
    }
    public BookIssueDto? AddBook(int bookid, int Memberid, CreateBookIssueRequest request)
    {
        Book? book = _context.Book.FirstOrDefault(b => b.BookId == bookid);
        Member? user = _context.Member.FirstOrDefault(u => u.MemberId == Memberid);

        if (book == null || user == null)
        {
            return null;
        }

        BookIssue? issuedBook = _context.BookIssue.FirstOrDefault(b => b.BookId == bookid && b.MemberId == Memberid);

        if (issuedBook is not null)
        {
            return null;
        }

        issuedBook = new BookIssue
        {
            BookId = bookid,
            MemberId = Memberid,
            IssueDate = request.IssueDate,
            ReturnDate = request.ReturnDate,
            RenewDate =  request.RenewDate,
            
        };

        _context.Add(issuedBook);
        _context.SaveChanges();

        return new BookIssueDto(
            issuedBook.IssueId,
            user.MemberName,
            book.BookId,
            book.BookName,
            user.MemberId,
            issuedBook.IssueDate,
            issuedBook.ReturnDate,
            issuedBook.RenewDate
        );
    }

    
}