using System.ComponentModel.DataAnnotations;
namespace BooksApi.Persistence;

public class Member
{
    public int MemberId { get; set; }
   
    public string MemberName { get; set; } = string.Empty;
  
    public string MemberType { get; set; } = string.Empty;

    public ICollection<BookIssue> BookIssues { get; set; } = new List<BookIssue>();
}