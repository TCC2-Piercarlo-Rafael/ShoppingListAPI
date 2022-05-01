namespace ShoppingListAPI.Dtos
{
    public class ItemDto
    {
        public Guid CategoryId { get; set; }
        public string Description { get; set; } = String.Empty;
    }
}
