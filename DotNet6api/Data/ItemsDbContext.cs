using DotNet6api.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet6api.Data
{
    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
