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
        public bool AddColor(long noteId, string color)
        {
            try
            {
                bool result = this.notesRL.AddColour(noteId, color);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AddReminder(long notesId, string reminder)
        {
            try
            {
                bool result = this.notesRL.AddReminder(notesId, reminder);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ArchieveOrUnArchieve(long noteId)
        {
            try
            {
                string result = this.notesRL.ArchieveOrUnarchieve(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
        public string IsTrash(int noteId)
        {
            try
            {
                string result = this.notesRL.IsTrash(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string PinOrUnpin(long noteId)
        {
            try
            {
                return this.notesRL.PinOrUnpin(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveNote(long noteId)
        {
            try
            {
                bool result = this.notesRL.RemoveNote(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NotesModel> RetrieveTrashNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesRL.RetrieveTrashNotes();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateNotes(Notess notes)
            {
                try
                {
                    string result = this.notesRL.UpdateNotes(notes);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
    } 
}

