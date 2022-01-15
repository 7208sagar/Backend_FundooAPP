namespace BussinessLayer.Interfaces
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using CommonLayer.Model;
    using RepositoryLayer.Entities;
    public interface ILabelBL
    {
       public bool CreateLabels(LabelModel model, long Id);
        IEnumerable<Labelss> RetrieveLables();
        bool RemoveLable(long lableId);
        bool EditLabel(NewLabelModel model, long labelId);
    }
}
