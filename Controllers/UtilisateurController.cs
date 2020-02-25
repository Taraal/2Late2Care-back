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
    public class UtilisateurController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UtilisateurController> _logger;

        public UtilisateurController(ILogger<UtilisateurController> logger)
        {
            _logger = logger;
        }

        
        [HttpPost]
        public void Post([FromForm]string pseudo, [FromForm]string mdp, [FromForm]string classe)
        {
            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                Utilisateur dbUtilisateur = new Utilisateur();
                dbUtilisateur.pseudo = pseudo;
                dbUtilisateur.mdp = mdp;
                dbUtilisateur.classe = dbContext.Classes.Where(c => c.libelle == classe).First();
                dbContext.Utilisateurs.Add(dbUtilisateur);
                dbContext.SaveChanges();
            }
        }
        

        /*
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Ticket
            {
                titre = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        */
    }
}
