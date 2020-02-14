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
    public class ClasseController : ControllerBase
    {

        private readonly ILogger<ClasseController> _logger;

        public ClasseController(ILogger<ClasseController> logger)
        {
            _logger = logger;
        }

        
        
        [HttpPost]
        public void Post([FromBody] Classe Classe)
        {
            DbContextOptionsBuilder<ContexteBDD> optionsBuilder = new DbContextOptionsBuilder<ContexteBDD>();
            var one = ConfigurationManager.ConnectionStrings;
            var random = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            string docstring = random.ConnectionString;

            optionsBuilder.UseMySql(docstring);

            using (Models.ContexteBDD dbContext = new Models.ContexteBDD(optionsBuilder.Options))
            {
                Classe dbClasse = new Classe();
                dbClasse.libelle = Classe.libelle;
                dbContext.Classes.Add(dbClasse);
                dbContext.SaveChanges();
            }
        }
        
        
    }
}
