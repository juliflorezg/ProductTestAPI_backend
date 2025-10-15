using Microsoft.EntityFrameworkCore;

namespace ProductAPI_backend.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
