using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _2Late2CareBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Pomelo.EntityFrameworkCore.MySql;

namespace _2Late2CareBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {

        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet]
        public IEnumerable<Ticket> GetAll()
        {
            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                return dbContext.Tickets;
            }
        
        }

        [HttpPost]
        public void addTicket([FromForm]Utilisateur utilisateur, [FromForm]string titre,[FromForm]string urlphoto, [FromForm]string description, [FromForm] List<Tag> tags){

            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                Ticket dbTicket = new Ticket();
                dbTicket.auteur = utilisateur;
                dbTicket.titre = titre;
                dbTicket.description = description;
                dbTicket.date = DateTime.Now;
                dbTicket.urlPhoto = urlphoto;
                dbContext.Tickets.Add(dbTicket);
                foreach (Tag tag in tags)
                {
                    TicketTag ticketTag = new TicketTag();
                    ticketTag.tag = tag;
                    ticketTag.ticket = dbTicket;
                    tag.TicketTags.Add(ticketTag);
                    dbTicket.TicketTags.Add(ticketTag);
                }
                dbContext.SaveChanges();
            }
        }

        [Route("/month")]
        [HttpGet]
        public IEnumerable<Ticket> GetTopMonth()
        {
            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                return dbContext.Tickets.FromSqlRaw("Select * FROM Tickets WHERE ");
            }
        
        }
        
    }
}
