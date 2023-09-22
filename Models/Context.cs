using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Context : DbContext
    {
        public DbSet<Sample> Samples { get;set;}

        public Context(DbContextOptions options) : base(options)
        {
            
        }
    }
}
