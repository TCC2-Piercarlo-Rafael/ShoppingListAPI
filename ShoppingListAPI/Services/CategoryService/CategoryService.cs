using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IUserService _userService;
        private readonly DataContext _context;

        public CategoryService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public List<Category> Get()
        {
            return _context.Categories.Where(c => c.UserId == _userService.GetId()).ToList();
        }

        public Category GetById(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public void Add(CategoryDto request)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                UserId = _userService.GetId(),
                Description = request.Description,
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
