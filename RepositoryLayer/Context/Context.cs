using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using System.Collections.Generic;

namespace RepositoryLayer
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users {get;set;}
        public DbSet<Notess> NotessssTables{ get; set; }
    }
}
