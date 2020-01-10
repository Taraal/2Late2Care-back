using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Late2CareBack
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string titre {get; set;}

        [StringLength(150)]
        [Required]
        public string description {get; set;}

        [Required]
        public Utilisateur auteur {get; set;}

        public string urlPhoto {get; set;}

        public ICollection<Tag> Tags { get; set; }

    }
}
