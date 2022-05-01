using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;

namespace ShoppingListAPI.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Item> _repository;
        private readonly IUserService _userService;
        public ItemService(IRepository<Item> repository, IRepository<Category> categoryRepository, IUserService userService)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _userService = userService;
        }

        public List<Item> Get()
        {
            var categories = _categoryRepository.GetAll(c => c.UserId == _userService.GetId());

            var items = new List<Item>();
            foreach (var category in categories)
                items.AddRange(category.Items);

            return items;
        }

        public Item GetById(Guid id)
        {
            return _repository.GetById(id).Result;
        }

        public void Add(ItemDto request)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                CategoryId = request.CategoryId,
                Description = request.Description,
                Complete = false
            };

            _repository.Add(item);
        }

        public void Update(Item item)
        {
            _repository.Update(item);
        }

        public void Delete(Item item)
        {
            _repository.Delete(item);
        }
    }
}
