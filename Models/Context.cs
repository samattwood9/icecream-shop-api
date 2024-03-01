using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Context : DbContext
    {
        public DbSet<Flavour> Flavours { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
            
        }
    }
}
