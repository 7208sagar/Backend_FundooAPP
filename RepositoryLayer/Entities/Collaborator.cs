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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollaboratorId { get; set; }

        [ForeignKey("NotessssTables")]
        public long NotesId { get; set; }
        public Notess Notes { get; set; }

        [Required]
        public string SenderEmail { get; set; }

        [Required]
        public string ReceiverEmail { get; set; }
    }
}
