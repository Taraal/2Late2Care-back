using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Late2CareBack
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string pseudo {get; set;}

        [Required]
        public Classe classe {get; set;}

        [Required]
        public string mail {get; set;}

    }
}
