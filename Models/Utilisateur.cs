using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Late2CareBack
{
    class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        private string pseudo {get; set;}

        [Required]
        private Classe classe {get; set;}

        [Required]
        private string mail {get; set;}

    }
}
