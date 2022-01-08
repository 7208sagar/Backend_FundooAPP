using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ICollaboratorRL
    {
       public bool AddCollaborator(CollaboratorModel collaborators);
       public bool RemoveCollaborator(long collaboratorId);
    }
}
