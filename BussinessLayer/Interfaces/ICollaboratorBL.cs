namespace BussinessLayer.Interfaces
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using CommonLayer.Model;
    using RepositoryLayer.Entities;
    public interface ICollaboratorBL
    {
       public bool AddCollaborator(CollaboratorModel collaborators, long Id);
        public bool RemoveCollaborator(long collaboratorId);
        IEnumerable<Collaborator> GetAllCollaborator();
    }
}
