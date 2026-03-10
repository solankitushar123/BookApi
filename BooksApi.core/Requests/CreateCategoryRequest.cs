using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApi.core.Requests
{

    public sealed class CreateCategoryRequest(string Name)
    {
        public string Name { get; } = Name;
    }

}
