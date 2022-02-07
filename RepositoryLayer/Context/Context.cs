using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;

namespace RepositoryLayer
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users {get; set; }
        public DbSet<Notess> NotessssTables { get; set; }
        public DbSet<Collaborator> CollaboratorT { get; set; }
        public DbSet<Labelss> LabelT { get; set; } 

    }
}
