using Microsoft.AspNetCore.Mvc;

namespace todoDotNet6.Controllers;

[ApiController]
[Route("weather")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("forecast/{id}")]
    public ActionResult<IEnumerable<WeatherForecast>> Get(int id)
    {
        // return NotFound(); // status code 404
        // return Unauthorized();  // status code 401
        // return BadRequest(); // status code 400
        // return NoContent(); // status code 204
        // return Ok(); // status code 200


        return Enumerable.Range(id, id).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
    }
}
