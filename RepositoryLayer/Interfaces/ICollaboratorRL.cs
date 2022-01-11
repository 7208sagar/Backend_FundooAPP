using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ICollaboratorRL
    {
       public bool AddCollaborator(CollaboratorModel collaborators);
       public bool RemoveCollaborator(long collaboratorId);
        IEnumerable<Collaborator> GetAllCollaborator();
    }
}
