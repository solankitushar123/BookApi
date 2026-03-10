using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BooksApi.core.Dtos
{
    public sealed class BookDto(
        int bookId,
        string bookName,
        string Publishers,
        string author,
        int categoryId
       
    )
    {
        [Key]
        public int BookId { get; } = bookId;
        public string BookName { get; } = bookName;
        public string Author { get; } = author;

        public string? Publishers { get; } = Publishers;
        public int CategoryId { get; } = categoryId;

       
    }
}