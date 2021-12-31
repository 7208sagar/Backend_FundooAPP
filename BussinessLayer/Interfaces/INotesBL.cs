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
        object UpdateNotes(long id, Notess note);
    }
}
