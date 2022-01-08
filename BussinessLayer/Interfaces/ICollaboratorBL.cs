﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface ICollaboratorBL
    {
       public bool AddCollaborator(CollaboratorModel collaborators);
        public bool RemoveCollaborator(long collaboratorId);
    }
}
