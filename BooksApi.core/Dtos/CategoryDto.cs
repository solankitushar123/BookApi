using System.Xml.Linq;

namespace BooksApi.Core.Dtos;
public class CategoryDto(
    int categoryId, 
    string CategoryName
    )
{
    public int CategoryId { get; set; } = categoryId;
    public string CategoryName { get; set; } = CategoryName;
}