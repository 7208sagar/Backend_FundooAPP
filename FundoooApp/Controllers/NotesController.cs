using BussinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundoooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpPut("Update")]
        public IActionResult UpdateNote(long Id, [FromBody] Notess note)
        {
            try
            {
                var update = this.notesBL.UpdateNotes(Id, note);
                return Ok(new { Success = true, message = "Notes Updated Successful", update });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
    }
}

