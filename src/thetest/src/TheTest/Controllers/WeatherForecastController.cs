using Microsoft.AspNetCore.Mvc;
using TheTest.ServiceA;

namespace TheTest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly Application _application;
    
    private static List<string> _summaries = new()
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _application = new Application();
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {   
        
        _summaries.Add(_application.GetAppOwner());
        
        var arr= Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _summaries[Random.Shared.Next(_summaries.Count)]
            })
            .ToArray();

        return arr;
    }
}