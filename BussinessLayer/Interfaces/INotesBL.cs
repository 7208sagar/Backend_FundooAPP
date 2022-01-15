namespace BussinessLayer.Interfaces
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Http;
    using RepositoryLayer.Entities;
    public interface INotesBL
    {
        public bool CreateNote(NotesModel notes);
        IEnumerable<Notess> GetAllNotes();
        public bool RemoveNote(long noteId);
        public string PinOrUnpin(long noteId);
        public string ArchieveOrUnArchieve(long noteId);
        public bool AddColor(long noteId, string color);
        public string IsTrash(int noteId);
        IEnumerable<NotesModel> RetrieveTrashNotes();
        bool AddReminder(long notesId, string reminder);
        bool UploadImage(long noteId, IFormFile image);
        bool UpdateNotes(UpdateNotesModel model, long notesId);
    }
}
