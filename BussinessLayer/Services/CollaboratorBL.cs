using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class CollaboratorBL : ICollaboratorBL
    {
        ICollaboratorRL collaboratorRL;
        public CollaboratorBL(ICollaboratorRL collaboratorRL)
        {
            this.collaboratorRL = collaboratorRL;
        }
        public bool AddCollaborator(CollaboratorModel collaborators)
        {
            try
            {
                return this.collaboratorRL.AddCollaborator(collaborators);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool RemoveCollaborator(long collaboratorId)
        {
            try
            {
                return this.collaboratorRL.RemoveCollaborator(collaboratorId);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
