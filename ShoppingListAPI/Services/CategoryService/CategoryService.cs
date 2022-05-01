using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;

namespace ShoppingListAPI.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IUserService _userService;
        public CategoryService(IRepository<Category> repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public List<Category> Get()
        {
            return _repository.GetAll(c => c.UserId == _userService.GetId()).ToList();
        }

        public Category GetById(Guid id)
        {
            return _repository.GetById(id).Result;
        }

        public void Add(CategoryDto request)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                UserId = _userService.GetId(),
                Description = request.Description,
            };

            _repository.Add(category);
        }

        public void Update(Category category)
        {
            _repository.Update(category);
        }

        public void Delete(Category category)
        {
            _repository.Delete(category);
        }
    }
}
