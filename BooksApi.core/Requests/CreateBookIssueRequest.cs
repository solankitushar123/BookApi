using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BooksApi.core.Requests
{
    public class CreateBookIssueRequest
    {
    
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; } 
        public DateTime? RenewDate { get; set; }
    }
}
