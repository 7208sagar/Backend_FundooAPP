using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
   public class Collaborator
    {
        [Key]
        public int CollaboratorId { get; set; }

        [ForeignKey("NoteId")]
        public int NotesId { get; set; }
       
        public Notess Notess { get; set; }
        public string Collab_EmailId { get; set; }
    }
}
