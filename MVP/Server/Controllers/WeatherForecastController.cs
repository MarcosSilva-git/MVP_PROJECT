using Microsoft.AspNetCore.Mvc;
using MVP.Infra.Context;
using MVP.Server.Controllers.Generics;
using MVP.Shared;
using MVP.Shared.Services;

namespace MVP.Server.Controllers
{
    public class WeatherForecastController : HelpDeskControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly UserService UserService;

        public WeatherForecastController(
            HelpDeskContext helpDeskContext,
            UserService userService,
            ILogger<WeatherForecastController> logger) : base(helpDeskContext)
        {
            _logger = logger;
            UserService = userService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetUser")]
        public string GetUser()
            => UserService.GetUserName();
    }
}