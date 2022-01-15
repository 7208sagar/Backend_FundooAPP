using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    /// <summary>
    /// LabelRL class
    /// </summary>
   public class LabelRL:ILabelRL
    {
        /// <summary>
        /// User context
        /// </summary>
        Context context;
        public LabelRL(Context context)
        {
            this.context = context;
        }
        /// <summary>
        /// Add the labels
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Createlabels(LabelModel model,long Id)
        {
            try
            {
                Labelss newLabel = new Labelss();
                newLabel.Labels = model.Labels;
                newLabel.NotesId = model.NotesId;
                newLabel.Id = Id;
                //Adding the data to database
                this.context.LabelT.Add(newLabel);
                //Save the changes in database
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
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Retrieve the all Lables
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Labelss> RetrieveLables()
        {
            try
            {
                return context.LabelT.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Remove Labels
        /// </summary>
        /// <param name="lableId"></param>
        /// <returns></returns>
        public bool RemoveLable(long lableId)
        {
            try
            {
                if (lableId > 0)
                {
                    var lables = this.context.LabelT.Where(x => x.LableId == lableId).SingleOrDefault();
                    this.context.LabelT.Remove(lables);
                    this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool EditLabel(NewLabelModel model, long labelId)
        {
            try
            {
                var lab = this.context.LabelT.Where(x => x.LableId == labelId).SingleOrDefault();
                if (lab != null)
                {
                    lab.Labels = model.Labels;
                    this.context.Update(lab);
                    this.context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
