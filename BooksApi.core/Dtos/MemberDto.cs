namespace BooksApi.Core.Dtos;

public class MemberDto
{
    public MemberDto(int memberId, string memberName, string memberType)
    {
        MemberId = memberId;
        MemberName = memberName;
        MemberType = memberType;
    }

    public int MemberId { get; }
    public string MemberName { get; }
    public string MemberType { get; }
}