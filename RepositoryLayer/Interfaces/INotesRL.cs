using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface INotesRL
    {
        public bool CreateNote(NotesModel notes);
        IEnumerable<Notess> GetAllNotes();
        object UpdateNotes(long noteId, Notess notes);
    }
}
