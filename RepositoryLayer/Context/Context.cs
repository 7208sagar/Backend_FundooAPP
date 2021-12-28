using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users {get;set;}
    }
}
