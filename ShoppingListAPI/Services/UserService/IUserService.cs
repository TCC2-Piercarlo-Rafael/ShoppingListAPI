using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services.UserService
{
    public interface IUserService
    {
        List<User> Get();
        Guid GetId();
        User GetById(Guid id);
        List<User> GetFiltered(Func<User, bool> lambda);
        void Add(UserDto request);
        void Update(User item);
        void Delete(User item);
    }
}
