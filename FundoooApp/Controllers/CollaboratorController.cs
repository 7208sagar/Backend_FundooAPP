using BussinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundoooApp.Controllers
{
    /// <summary>
    /// CollaboratorController class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorBL collaboratorBL;

        public CollaboratorController(ICollaboratorBL collaboratorBL)
        {
            this.collaboratorBL = collaboratorBL;
        }
        /// <summary>
        /// Adds the collaborators
        /// </summary>
        /// <param name="collaborators"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addCollaborators")]
        public ActionResult AddCollaborators(CollaboratorModel collaborators)
        {
            try
            {
                var Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (this.collaboratorBL.AddCollaborator(collaborators,Id))
                {
                    return this.Ok(new { Status = true, Message = "Sucessfully Added New Collaborator", Data = collaborators });
                }
                return this.BadRequest(new { Status = false, Message = "Failed to add Collaborator" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="collaboratorId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("collaboratorId")]
        public IActionResult RemoveCollaborator(long collaboratorId)
        {
            try
            {
                bool result = this.collaboratorBL.RemoveCollaborator(collaboratorId);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Collaborator Deleted Sucessfully", Data = collaboratorId });
                }
                return this.BadRequest(new { Status = false, Message = "Unable to delete collaborator : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Retrieves all collaborator
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CollaboratorAllData")]
        public IActionResult GetAllData()
        {
            try
            {
                IEnumerable<Collaborator> collaborators = collaboratorBL.GetAllCollaborator();
                if (collaborators == null)
                {
                    return BadRequest(new { Success = false, message = "No collaborator Found" });
                }
                return Ok(new { Success = true, message = "  Retrieve Collaborator Successfully", Data = collaborators });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
