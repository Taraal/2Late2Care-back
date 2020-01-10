using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Late2CareBack
{
    class Ticket
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        private string titre {get; set;}

        [StringLength(150)]
        [Required]
        private string description {get; set;}

        [Required]
        private Utilisateur auteur {get; set;}

        private string urlPhoto {get; set;}

        public ICollection<Tag> Tags { get; set; } 

    }
}
