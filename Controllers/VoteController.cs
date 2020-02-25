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
    public class VoteController : ControllerBase
    {

        private readonly ILogger<VoteController> _logger;

        public VoteController(ILogger<VoteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Get([FromQuery]int ticketId){
            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                IEnumerable<Vote> votes = dbContext.Votes.Where(v => v.ticketId == ticketId);
                return votes.Count();
            }
        }
        
        [HttpPost]
        public void Post([FromBody] Vote Vote)
        {
            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                Vote dbVote = new Vote();
                dbVote.utilisateurId = Vote.utilisateurId;
                dbVote.ticketId = Vote.ticketId;
                dbContext.Votes.Add(dbVote);
                dbContext.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete([FromBody] Vote vote){
            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                dbContext.Votes.Remove(vote);
            }

        }

        
    }
}
