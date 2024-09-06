using Microsoft.AspNetCore.Mvc;
using TMDBMovieList.Server.Enitites;

namespace TMDBMovieList.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PaoController> _logger;

        public PaoController(ILogger<PaoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPao")]
        public IEnumerable<Pao> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Pao
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Flavor = "Hot",
                Price = Random.Shared.Next(-5, 5)
            })
            .ToArray();
        }
    }
}
