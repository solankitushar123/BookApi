
using BooksApi.core.Requests;
using BooksApi.Core.Dtos;
using BooksApi.Persistence;
using BooksApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TestMinimalApi.Web.Endpoints;

public static class MemberEndpoints
{
   

    public static IEndpointRouteBuilder MapMemberGroup(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGroup("Member");
    }

    public static IEndpointRouteBuilder MapMemberEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        IEndpointRouteBuilder MemberGroup = endpoints.MapMemberGroup();

        MemberGroup.MapGet("", GetMember);
        MemberGroup.MapGet("{id:int}", GetMemberId);
        MemberGroup.MapPost("", CreateMember);

        return endpoints;
    }

    public static Ok<IEnumerable<MemberDto>> GetMember(MemberService service)
    {
        IEnumerable<MemberDto> list = service.GetAll();
        return TypedResults.Ok(list);
    }

    public static IResult GetMemberId(MemberService service, int id)
    {
        MemberDto? Member = service.GetAll().FirstOrDefault(b => b.MemberId == id);
        return Member is null ? TypedResults.NotFound() : TypedResults.Ok(Member);
    }
    public static IResult CreateMember(MemberService service, CreateMemberRequest request)
    {
        MemberDto? created = service.AddUser(request);
        return TypedResults.Created($"/Member", created);
    }
}

