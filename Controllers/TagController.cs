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
    public class TagController : ControllerBase
    {

        private readonly ILogger<TagController> _logger;

        public TagController(ILogger<TagController> logger)
        {
            _logger = logger;
        }

        [Route("/{libelle}/tickets")]
        [HttpGet]
        public IEnumerable<Ticket> GetTicketsByTag([FromRoute]string libelle){
            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                return dbContext.Tickets.FromSqlRaw("SELECT * FROM Tickets t JOIN TicketTags tt ON t.Id = tt.TicketId WHERE tt.libelle = ?", libelle);
            }
        }

        [HttpGet]
        public IEnumerable<Tag> GetAll(){
            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                return dbContext.Tags;
            }

        }        
        
        [HttpPost]
        public void Post([FromBody] Tag tag)
        {
            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                Tag dbTag = new Tag();
                dbTag.libelle = tag.libelle;
                dbContext.Tags.Add(dbTag);
                dbContext.SaveChanges();
            }
        }
        
        
    }
}
