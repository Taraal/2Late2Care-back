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

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TagController> _logger;

        public TagController(ILogger<TagController> logger)
        {
            _logger = logger;
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
        

        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Tag
            {
                Id = index,
                libelle = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
    }
}
