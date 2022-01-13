﻿using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface ILabelBL
    {
       public bool CreateLabels(LabelModel model, long Id);
        IEnumerable<Labelss> RetrieveLables();
        bool RemoveLable(long lableId);
    }
}
