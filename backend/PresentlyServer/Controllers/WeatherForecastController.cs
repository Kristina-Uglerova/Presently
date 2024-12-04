using Microsoft.AspNetCore.Mvc;
using PresentlyServer.Models;

namespace PresentlyServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(PresentlyDbContext presentlyDbContext) : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet(Name = "GetWeatherForecast")]
        public void Get()
        {
            DbUser dbUser = new DbUser
            {
                Username = "a",
                Email = "b",
                Birthday = DateTime.Today,
                Salt = new byte[0],
                Hash = new byte[0]
            };
            presentlyDbContext.Users.Add(dbUser);
            presentlyDbContext.SaveChanges();
        }
    }
}
