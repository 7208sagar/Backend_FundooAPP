using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
   public interface INotesBL
    {
        public bool CreateNote(NotesModel notes);
        IEnumerable<Notess> GetAllNotes();
      
        public bool RemoveNote(long noteId);
        public string PinOrUnpin(long noteId);
        public string UpdateNotes(Notess notes);
    }
}
