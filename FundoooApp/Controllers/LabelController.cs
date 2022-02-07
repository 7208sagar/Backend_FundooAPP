using BussinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    ///LabelController class
    public class LabelController : ControllerBase
    {
        private readonly ILabelBL labelBL;
        public LabelController(ILabelBL labelBL)
        {
            this.labelBL = labelBL;
        }

        /// <summary>
        /// Add label
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addLable")]
        public IActionResult CreateLabels(LabelModel model)
        {
            try
            {
                var Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                bool result = this.labelBL.CreateLabels(model, Id);
                if (result.Equals(true))
                {
                    return this.Ok(new{ Status = true, Message = "Add Lable Sucessfully", Data = model});
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Add Lable" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// RetrieveAllLables
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RetrieveAllLables()
        {
            try
            {
                IEnumerable<Labelss> result = this.labelBL.RetrieveLables();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieve Lables Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Lables" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Delete label with id
        /// </summary>
        /// <param name="lableId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("lableId")]
        public IActionResult DeleteLable(long lableId)
        {
            try
            {
                bool result = this.labelBL.RemoveLable(lableId);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Delete Lable Sucessfully", Data = lableId });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to delete lable : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Update label
        /// </summary>
        /// <param name="model"></param>
        /// <param name="labelId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public IActionResult EditLabel(NewLabelModel model, long labelId)
        {
            try
            {
                bool result = this.labelBL.EditLabel(model, labelId);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "update Lable Sucessfully", data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to update lable : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
    }
}
