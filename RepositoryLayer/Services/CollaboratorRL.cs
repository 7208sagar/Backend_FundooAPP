using CommonLayer.Model;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CollaboratorRL : ICollaboratorRL
    {
        Context context;
        public CollaboratorRL(Context context)
        {
            this.context = context;
        }
        public bool AddCollaborator(CollaboratorModel collaborators,long Id)
        {
            try
            {
                var Collaborator = this.context.NotessssTables.Where(x =>x.NotesId == collaborators.NotesId).SingleOrDefault();
                var Collaborator1 = this.context.Users.Where(x => x.EmailId == collaborators.EmailId).SingleOrDefault();
                if (Collaborator != null && Collaborator1!=null)
                {
                    Collaborator newCollaborator = new Collaborator();
                    newCollaborator.Id = Id;
                    newCollaborator.NotesId = collaborators.NotesId;
                    newCollaborator.EmailId = collaborators.EmailId;
                    this.context.CollaboratorT.Add(newCollaborator);
                }
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool RemoveCollaborator(long collaboratorId)
        {
            try
            {
                if (collaboratorId > 0)
                {
                    var collaborator = this.context.CollaboratorT.Where(x => x.CollaboratorId == collaboratorId).SingleOrDefault();
                    this.context.CollaboratorT.Remove(collaborator);
                    this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Collaborator> GetAllCollaborator()
        {
            try
            {
                return this.context.CollaboratorT.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
