using System.ComponentModel;

namespace ShoppingListAPI.Utils
{
    public enum UserRole
    {
        [Description("Admin")]
        Admin = 1,

        [Description("User")]
        User = 2
    }
}
