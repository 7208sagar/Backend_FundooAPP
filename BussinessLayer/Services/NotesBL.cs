using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
   public class NotesBL : INotesBL
    {
        INotesRL notesRL;
        public NotesBL(INotesRL notesRL)

        {
            this.notesRL = notesRL;

        }
        public bool CreateNote(NotesModel notes)
        {
            try
            {
                return this.notesRL.CreateNote(notes);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<Notess> GetAllNotes()
        {
            try
            {
                return this.notesRL.GetAllNotes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public object UpdateNotes(long id, Notess note)
        {
            try
            {
                return this.notesRL.UpdateNotes(id, note);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
