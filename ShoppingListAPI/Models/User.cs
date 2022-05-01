using ShoppingListAPI.Utils;
using System.Text.Json.Serialization;

namespace ShoppingListAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public UserRole Roles { get; set; }

        [JsonIgnore]
        public List<Category> Categories { get; set; }
    }
}
