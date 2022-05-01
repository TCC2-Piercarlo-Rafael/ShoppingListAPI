using System.Text.Json.Serialization;

namespace ShoppingListAPI.Models
{
    public class Category
    {
        public Category()
        {
            Items = new List<Item>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; } = String.Empty;

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual List<Item> Items { get; set; }

    }
}
