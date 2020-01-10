using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _2Late2CareBack.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;


namespace _2Late2CareBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        
        //ContexteBDD dbContext = new Models.ContexteBDD(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));

        //ContexteBDD dbContextt = new Models.ContexteBDD(options => new DbContextOptionsBuilder());
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TagController> _logger;

        public TagController(ILogger<TagController> logger)
        {
            _logger = logger;
        }

        public void Post([FromBody] Tag tag)
    {
        using (Models.ContexteBDD dbContext = new Models.ContexteBDD())
        {
            dbContext.Employees.Add(employee);
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
