namespace BussinessLayer.Services
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
    using RepositoryLayer.Entities;
    using RepositoryLayer.Interfaces;
    /// <summary>
    ///  CollaboratorBL class
    /// </summary>
    public class CollaboratorBL : ICollaboratorBL
    {
        private ICollaboratorRL collaboratorRL;
        public CollaboratorBL(ICollaboratorRL collaboratorRL)
        {
            this.collaboratorRL = collaboratorRL;
        }

        public bool AddCollaborator(CollaboratorModel collaborators, long Id)
        {
            try
            {
                return this.collaboratorRL.AddCollaborator(collaborators, Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Collaborator> GetAllCollaborator()
        {
            try
            {
                return this.collaboratorRL.GetAllCollaborator();
            }
            catch (Exception)
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
                throw new Exception(e.Message);
            }
        }
    }
}
