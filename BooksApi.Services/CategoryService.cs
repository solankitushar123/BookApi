using BooksApi.core.Dtos;
using BooksApi.core.Requests;
using BooksApi.Core.Dtos;
using BooksApi.Persistence;

namespace BooksApi.Services;

public sealed class CategoryService
{
    private readonly AppDbContext _dbContext;

    public CategoryService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IEnumerable<CategoryDto> GetAll() => _dbContext.Category

            .Select(Category => new CategoryDto(Category.CategoryId,Category.CategoryName))
            .ToList();

    public CategoryDto? AddCategory(CreateCategoryRequest request)
    {
        Category? category = _dbContext.Category.FirstOrDefault(c => c.CategoryName == request.Name);
        if (category is not null)
        {
            return null;
        }
        category = new Category { CategoryName = request.Name };
        _dbContext.Add(category);
        _dbContext.SaveChanges();
        return new CategoryDto(category.CategoryId, category.CategoryName);
    }
}