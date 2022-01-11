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

        [ForeignKey("NotesTable")]
        public long NotesId { get; set; }
        public Notess Notes { get; set; }

        [ForeignKey("Users")]
        public long Id { get; set; }
        public User User { get; set; }

        [Required]
        public string EmailId { get; set; }
    }
}
