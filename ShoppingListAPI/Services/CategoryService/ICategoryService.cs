using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Get();
        Category GetById(Guid id);
        void Add(CategoryDto request);
        void Update(Category category);
        void Delete(Category category);
    }
}
