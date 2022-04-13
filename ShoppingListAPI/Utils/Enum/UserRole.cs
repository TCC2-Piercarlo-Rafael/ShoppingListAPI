namespace ShoppingListAPI.Utils.Enum
{
    [Flags]
    public enum UserRole
    {
        Create = 1,
        Update = 2,
        Read = 4,
        Delete = 8
    }
}
