using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApi.core.Requests
{
    public class CreateMemberRequest   
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }

        public string MemberType { get; set; }

    }
    }

