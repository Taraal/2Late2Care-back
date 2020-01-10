using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _2Late2CareBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
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
