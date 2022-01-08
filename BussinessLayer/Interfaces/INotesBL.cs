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
        public string ArchieveOrUnArchieve(long noteId);
        public bool AddColor(long noteId, string color);
        public string IsTrash(int noteId);
        IEnumerable<NotesModel> RetrieveTrashNotes();
        bool AddReminder(long notesId, string reminder);
    }
}
