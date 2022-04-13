using System.Text.Json.Serialization;

namespace ShoppingListAPI.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Complete { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
    }
}
