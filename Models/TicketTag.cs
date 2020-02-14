using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Late2CareBack
{
    public class TicketTag
    {

        public string libelle {get; set;}
        public Tag tag {get; set;}

        public int TicketId {get; set;}
        public Ticket ticket {get; set;}


    }
}
