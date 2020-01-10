using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Late2CareBack
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string libelle {get; set;}
    }
}
