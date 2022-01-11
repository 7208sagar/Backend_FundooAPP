using BussinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundoooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INotesBL notesBL;
        public NotesController(INotesBL notesBL)
        {
            this.notesBL = notesBL;
        }
        [HttpPost]
        public IActionResult CreateNote(NotesModel notes)
        {
            try
            {
                if (this.notesBL.CreateNote(notes))
                {
                    return this.Ok(new { Success = true, message = "New note created successfully " });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unsuccessful Notes not Added" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.InnerException });
            }
        }
        [HttpGet("AllNotesInfo")]
        public IActionResult GetAllData()
        {
            try
            {
                IEnumerable<Notess> notes = notesBL.GetAllNotes();
                if (notes == null)
                {
                    return BadRequest(new { Success = false, message = "No Notes Found" });
                }
                return Ok(new { Success = true, message = " ", notes });
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        [HttpDelete]
        [Route("{noteId}")]
        public IActionResult DeleteNotes(long noteId)
        {
            try
            {
                var result = this.notesBL.RemoveNote(noteId);
                if (result.Equals(true))
                {
                    return this.Ok(new { Success = true, message = "Delete Note Successfully" });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to delete note Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("updateNotes")]
        public IActionResult UpdateNotes([FromBody] Notess notes)
        {
            try
            {
                var result = this.notesBL.UpdateNotes(notes);
                if (result.Equals("UPDATE SUCCESSFULL"))
                {
                    return this.Ok(new { Success = true, message = "Note Updated successfully " });
                }

                return this.BadRequest(new { Status = false, Message = "Error while updating notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("pinOrUnpin")]
        public IActionResult PinOrUnpinNote(long noteId)
        {
            try
            {
                var result = this.notesBL.PinOrUnpin(noteId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "pinned successfully " });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("archieveOrUnarchieve")]
        public IActionResult ArchieveOrUnarchieve(long noteId)
        {
            try
            {
                var result = this.notesBL.ArchieveOrUnArchieve(noteId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Archieved successfully " });

                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("addColor")]
        public IActionResult AddColor(long noteId, string color)
        {
            try
            {
                var result = this.notesBL.AddColor(noteId, color);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Add Colour Sucessfully", Data = color });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("trashOrUntrash")]
        public IActionResult TrashOrUntrash(int noteId)
        {
            try
            {
                var result = this.notesBL.IsTrash(noteId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("retrieveAllTrashNotes")]
        public IActionResult RetrieveAllTrashNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesBL.RetrieveTrashNotes();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieve Notes Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/addreminder")]
        public IActionResult AddReminder(long notesId, string reminder)
        {
            try
            {
                bool result = this.notesBL.AddReminder(notesId, reminder);
                if (result.Equals("Remind added successfully"))
                {
                    return this.Ok(new { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("uploadImage")]
        public IActionResult UploadImage(long noteId, IFormFile image)
        {
            try
            {
                bool result = this.notesBL.UploadImage(noteId, image);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Upload Image Successfully", Data = noteId });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
    }
}

