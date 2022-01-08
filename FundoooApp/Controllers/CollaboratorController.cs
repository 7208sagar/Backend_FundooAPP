using BussinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundoooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorBL collaboratorBL;

        public CollaboratorController(ICollaboratorBL collaboratorBL)
        {
            this.collaboratorBL = collaboratorBL;
        }
        [HttpPost]
        [Route("addCollaborators")]
        public ActionResult AddCollaborators(CollaboratorModel collaborators)
        {
            try
            {
                if (this.collaboratorBL.AddCollaborator(collaborators))
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
    }
}
