using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly IUserService _userService;
        private readonly DataContext _context;

        public ItemService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public List<Item> Get()
        {
            var categories = _context.Categories.Include(categories => categories.Items).Where(c => c.UserId == _userService.GetId());

            var items = new List<Item>();
            foreach (var category in categories)
                items.AddRange(category.Items);

            return items;
        }

        public Item GetById(Guid id)
        {
            return _context.Items.Find(id);
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

            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void Update(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }

        public void Delete(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }
    }
}
