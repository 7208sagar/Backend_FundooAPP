using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
        public bool CreateLabels(LabelModel model, long Id)
        {
            try
            {
                return this.labelRL.Createlabels(model,Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool RemoveLable(long lableId)
        {
            try
            {
                return this.labelRL.RemoveLable(lableId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<Labelss> RetrieveLables()
        {
            try
            {
                return this.labelRL.RetrieveLables();
            }
            catch (Exception e)
            {
                throw;
            }
        
        }
    }
}
