using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface ICollaboratorBL
    {
       public bool AddCollaborator(CollaboratorModel collaborators);
        public bool RemoveCollaborator(long collaboratorId);
        IEnumerable<Collaborator> GetAllCollaborator();
    }
}
