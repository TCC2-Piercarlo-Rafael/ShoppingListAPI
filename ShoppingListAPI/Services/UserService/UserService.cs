using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;
using ShoppingListAPI.Utils;
using System.Security.Claims;

namespace ShoppingListAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;

        public UserService(IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        public Guid GetId()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid);
            }
            return Guid.Parse(result);
        }

        public List<User> GetFiltered(Func<User, bool> lambda)
        {
            return _context.Users.Where(lambda).ToList();
        }

        public User GetById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public void Add(UserDto request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Password = request.Password,
                Roles = UserRole.User
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
