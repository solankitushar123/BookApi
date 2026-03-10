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

}