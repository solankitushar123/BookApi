using BooksApi.core.Requests;
using BooksApi.Core.Dtos;
using BooksApi.Persistence;
using System.Reflection;

namespace BooksApi.Services;

public class MemberService
{
  
    private readonly AppDbContext _dbContext;

    public MemberService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IEnumerable<MemberDto> GetAll() => _dbContext.Member

            .Select(Member => new MemberDto(Member.MemberId, Member.MemberName, Member.MemberType))
            .ToList();
    public MemberDto? AddUser( CreateMemberRequest request)
    {
        Member? user = _dbContext.Member.FirstOrDefault(u => u.MemberName == request.MemberName);
        if (user is not null)
        {
            return null;
        }
        user = new Member
        {
            MemberName = request.MemberName,
            MemberType = request.MemberType,
        };
        _dbContext.Member.Add(user);
        _dbContext.SaveChanges();
        return new MemberDto(user.MemberId, user.MemberName, user.MemberType);
    }
}
   
