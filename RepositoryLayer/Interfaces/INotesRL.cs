﻿using CommonLayer.Model;
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
        bool RemoveNote(long noteId);
        public string PinOrUnpin(long noteId);
        string UpdateNotes(Notess notes);
        string ArchieveOrUnarchieve(long noteId);
        bool AddColour(long noteId, string color);
        string IsTrash(int noteId);
    }
}