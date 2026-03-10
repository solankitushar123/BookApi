using System.ComponentModel.DataAnnotations;

namespace BooksApi.Core.Requests
{
    public sealed class CreateBookRequest(

      
        string bookName,
        string author,
        string publishers,
        int categoryId

        )
    {
       
        [StringLength(100)]
        public required string BookName { get; set; } = bookName;

        
        [StringLength(100)]
        public required string Author { get; set; } = author;
        [StringLength(100)]
        public string Publishers { get; set; } = publishers;

        public required int CategoryId { get; set; } = categoryId;
     



    }
}