using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services.ItemService
{
    public interface IItemService
    {
        List<Item> Get();
        Item GetById(Guid id);
        void Add(ItemDto request);
        void Update(Item item);
        void Delete(Item item);
    }
}
