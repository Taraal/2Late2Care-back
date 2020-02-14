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

        [Required]
        public string libelle {get; set;}

        public virtual ICollection<TicketTag> TicketTags {get; set;}
    }
}
