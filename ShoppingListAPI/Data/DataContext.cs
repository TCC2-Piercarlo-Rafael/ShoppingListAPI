using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
