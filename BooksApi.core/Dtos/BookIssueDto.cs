namespace BooksApi.Core.Dtos;

public class BookIssueDto(
    int bookIssueId,
    string memberName,
    int bookId,
    string bookName,
    int memberId,
    DateTime issueDate,
    DateTime? returnDate,
    DateTime? renewDate)
{
   
    public  int BookIssueId { get; set; } = bookIssueId;
    public  int BookId { get; set; } = bookId;
    public  string BookName { get; set; } = bookName;
    public  string MemberName { get; set; } = memberName;
    public  int MemberId { get; set; } = memberId;
    public DateTime IssueDate { get; set; } = issueDate;
    public DateTime? ReturnDate { get; set; } = returnDate;
    public DateTime? RenewDate { get; set; } = renewDate;
}