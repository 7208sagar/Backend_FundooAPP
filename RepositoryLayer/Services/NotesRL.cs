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
        public object UpdateNotes(long noteId, Notess notes)
        {
                try
                {
                    var note = this.context.NotessssTables.FirstOrDefault(x => x.Id == noteId);
                    if (note != null)
                    {
                        note.Title = notes.Title;
                        note.Message = notes.Message;
                        note.Remainder = notes.Remainder;
                        note.Image = notes.Image;
                        note.IsArchive = notes.IsArchive;
                        note.IsPin = notes.IsPin;
                        note.IsTrash = notes.IsTrash;
                        note.Createdat = (DateTime)notes.Createdat;
                        this.context.SaveChanges();
                    }
                    return note;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
    }
    





