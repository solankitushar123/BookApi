

using BooksApi.core.Dtos;
using BooksApi.core.Requests;
using BooksApi.Core.Dtos;
using BooksApi.Core.Requests;
using BooksApi.Persistence;
using BooksApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TestMinimalApi.Web.Endpoints;

public static class CategoryEndpoints
{
   
    public static IEndpointRouteBuilder MapCategoryGroup(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGroup("Category");
    }

    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        IEndpointRouteBuilder CategoryGroup = endpoints.MapCategoryGroup();

        CategoryGroup.MapGet("", GetCategory);

        CategoryGroup.MapGet("{id:int}", GetCategoryId);


        CategoryGroup.MapGet("/name", GetCategoryName);

        CategoryGroup.MapPost("", CreateCategory);

        return endpoints;
    }

    public static Ok<IEnumerable<CategoryDto>> GetCategory(CategoryService service)
    {
        IEnumerable<CategoryDto> list = service.GetAll();
        return TypedResults.Ok(list);
    }

    public static IResult GetCategoryId(CategoryService service, int id)
    {
        CategoryDto? Category = service.GetAll().FirstOrDefault(b => b.CategoryId == id);
        return Category is null ? TypedResults.NotFound() : TypedResults.Ok(Category);
    }

    public static IResult GetCategoryName(CategoryService service, string CategoryName)
    {
        CategoryDto? Category = service.GetAll().FirstOrDefault(b => b.CategoryName == CategoryName);
        return Category is null ? TypedResults.NotFound() : TypedResults.Ok(Category);
    }
    public static IResult CreateCategory(CategoryService service, CreateCategoryRequest request)
    {
        CategoryDto? created = service.AddCategory(request);
        return TypedResults.Created($"/Category/{created.CategoryId}", created);
    }
}
