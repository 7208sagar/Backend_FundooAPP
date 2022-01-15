namespace BussinessLayer.Services
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
    using RepositoryLayer.Entities;
    using RepositoryLayer.Interfaces;
    public class LabelBL : ILabelBL
    {
       private ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }

        public bool CreateLabels(LabelModel model, long Id)
        {
            try
            {
                return this.labelRL.Createlabels(model, Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EditLabel(NewLabelModel model, long labelId)
        {
            try
            {
                return this.labelRL.EditLabel(model, labelId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
                throw new Exception(e.Message);
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
                throw new Exception(e.Message);
            }
        }
    }
}
