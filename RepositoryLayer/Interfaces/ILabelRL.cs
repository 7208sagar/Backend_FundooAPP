using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ILabelRL
    {
       public bool Createlabels(LabelModel model,long Id);
        IEnumerable<Labelss> RetrieveLables();
        bool RemoveLable(long lableId);
        bool EditLabel(NewLabelModel model, long labelId);
    }
}
