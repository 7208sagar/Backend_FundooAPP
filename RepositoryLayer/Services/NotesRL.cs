using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        IConfiguration configuration;
        public NotesRL(Context context, IConfiguration configuration)
        {
            this.context = context;
           this.configuration = configuration;
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
                            this.context.NotessssTables.Remove(notes);
                            this.context.SaveChangesAsync();
                            return true;                       
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
        public string ArchieveOrUnarchieve(long noteId)
        {
            try
            {
                var notes = this.context.NotessssTables.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (notes.IsArchive == false)
                {
                    notes.IsArchive = true;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Note is Archieve";
                    return message;
                }
                if (notes.IsArchive == true)
                {
                    notes.IsArchive = false;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Note UnArchieve";
                    return message;
                }
                return "Unable to Archieve or UnArchieve notes";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool AddColour(long noteId, string color)
        {
            try
            {
                var notes = this.context.NotessssTables.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (notes != null)
                {
                    notes.Colour = color;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string IsTrash(int noteId)
        {
            try
            {
                var notes = this.context.NotessssTables.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (notes.IsTrash == false)
                {
                    notes.IsTrash = true;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Notes Is Trashed";
                    return message;
                }
                if (notes.IsTrash == true)
                {
                    notes.IsTrash = false;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Note Restored";
                    return message;
                }

                return "Unable to Trash or Restored notes"; ;
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
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = (IEnumerable<NotesModel>)this.context.NotessssTables.Where(x => x.IsTrash == true).ToList();
                if (notes != null)
                {
                    result = notes;
                }
                else
                {
                    result = null;
                }
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
                var notes = this.context.NotessssTables.Where(x => x.NotesId == notesId).FirstOrDefault();
                if (notes != null)
                {
                    notes.Remainder = reminder;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UploadImage(long noteId, IFormFile noteimage)
        {
            try
            {
                var notes = this.context.NotessssTables.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (notes != null)
                {
                    Account account = new Account
                    (
                        configuration["CloudinaryAccount:CloudName"],
                        configuration["CloudinaryAccount:ApiKey"],
                        configuration["CloudinaryAccount:ApiSecret"]
                    );
                    var path = noteimage.OpenReadStream();
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(noteimage.FileName, path)
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    notes.Image = uploadResult.Url.ToString();
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
    





