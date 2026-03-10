using BooksApi.core.Dtos;
using BooksApi.Core.Requests;
using BooksApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BooksApi.Web.Endpoints;

public static class BookEndpoints
{
    public static IEndpointRouteBuilder MapBookGroup(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGroup("books");
    }

    public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        IEndpointRouteBuilder bookGroup = endpoints.MapBookGroup();

        bookGroup.MapGet("", GetBooks);
        bookGroup.MapGet("{id:int}", GetBook);
        bookGroup.MapPost("", CreateBook);

        return endpoints;
    }

    public static Ok<IEnumerable<BookDto>> GetBooks(BookService service)
    {
        IEnumerable<BookDto> list = service.GetAll();
        return TypedResults.Ok(list);
    }

    public static IResult GetBook(BookService service, int id)
    {
        BookDto? book = service.GetAll().FirstOrDefault(b => b.BookId == id);
        return book is null ? TypedResults.NotFound() : TypedResults.Ok(book);
    }
    public static IResult CreateBook(BookService service, CreateBookRequest request)
    {
        BookDto created = service.Create(request);
        return TypedResults.Created($"/Books/{created.BookId}", created);
    }
}