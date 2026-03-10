using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BooksApi.core.Requests
{
    internal class CreateBookIssueRequest
    {
        public int BookIssueId { get; set; }
        public int BookId { get; set; } 
        public string BookName { get; set; }
        public string MemberName { get; set; }
        public int MemberId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; } 
        public DateTime? RenewDate { get; set; }
    }
}
