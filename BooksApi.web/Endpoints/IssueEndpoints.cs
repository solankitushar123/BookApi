
using BooksApi.core.Requests;
using BooksApi.Core.Dtos;
using BooksApi.Services;
using LibraryApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace TestMinimalApi.Web.Endpoints;

public static class IssueEndpoints
{
    public static IEndpointRouteBuilder MapIssueBookGroup(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGroup("IssueBook");
    }

    public static IEndpointRouteBuilder MapIssueEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        IEndpointRouteBuilder IssueGroup = endpoints.MapIssueBookGroup();
        IssueGroup.MapGet("", GetIssueBook);
        IssueGroup.MapGet("{id:int}", GetIssueBookId);
        IssueGroup.MapPost("book/{bookid:int}/user/{Memberid:int}", AddIssuedBook);
        return endpoints;
    }

    public static Ok<IEnumerable<BookIssueDto>> GetIssueBook(IssueBookservice service)
    {
        IEnumerable<BookIssueDto> list = service.GetIssuedBook();
        return TypedResults.Ok(list);
    }

    public static IResult GetIssueBookId(IssueBookservice service, int id)
    {
        BookIssueDto? IssueBook = service.GetIssuedBook().FirstOrDefault(b => b.BookIssueId == id);
        return IssueBook is null ? TypedResults.NotFound() : TypedResults.Ok(IssueBook);
    }
    private static IResult AddIssuedBook(IssueBookservice service, int bookid, int Memberid, CreateBookIssueRequest request)
    {
        BookIssueDto? issuedbook = service.AddBook(bookid, Memberid, request);
        return issuedbook is null ? TypedResults.NotFound() : TypedResults.Ok(issuedbook);
    }
}