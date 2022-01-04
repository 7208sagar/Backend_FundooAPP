using CommonLayer.Model;
using CommonLayer.ResponseModel;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        Context context;
        public NotesRL(Context context)
        {
            this.context = context;
        }
        public bool CreateNote(NotesModel notes)
        {
            try
            {
                Notess newNotes = new Notess();
                newNotes.Id = notes.Id;
                newNotes.Title = notes.Title;
                newNotes.Message = notes.Message;
                newNotes.Remainder = notes.Remainder;
                newNotes.Colour = notes.Colour;
                newNotes.Image = notes.Image;
                newNotes.IsArchive = notes.IsArchive;
                newNotes.IsPin = notes.IsPin;
                newNotes.IsTrash = notes.IsTrash;
                newNotes.Createdat = DateTime.Now;
                this.context.NotessssTables.Add(newNotes);
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
        public IEnumerable<Notess> GetAllNotes()
        {
            try
            {
                return this.context.NotessssTables.ToList();
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
                if (noteId > 0)
                { 
                    var notes = this.context.NotessssTables.Where(x => x.NotesId == noteId).SingleOrDefault();
                    if (notes != null)
                    {
                        if (notes.IsTrash == true)
                        {
                            this.context.NotessssTables.Remove(notes);
                            this.context.SaveChangesAsync();
                            return true;
                        }
                    }
                }
                return false;
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
                var notes = this.context.NotessssTables.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (notes.IsPin == false)
                {
                    notes.IsPin = true;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Note is getting pin";
                    return message;
                }
                if (notes.IsPin == true)
                {
                    notes.IsPin = false;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Note Unpinned";
                    return message;
                }
                return "Unable to Pin or Unpin notes";
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
                if (notes.NotesId != 0)
                {
                    this.context.Entry(notes).State = EntityState.Modified;
                    this.context.SaveChanges();
                    return "UPDATE SUCCESSFULL";
                }
                return "Updation Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
    





