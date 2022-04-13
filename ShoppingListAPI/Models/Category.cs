using System.Text.Json.Serialization;

namespace ShoppingListAPI.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; } = String.Empty;

        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public List<Item> Items { get; set; }

    }
}
