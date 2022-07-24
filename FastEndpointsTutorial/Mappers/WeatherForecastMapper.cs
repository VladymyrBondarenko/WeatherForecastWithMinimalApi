using EndpointsTutorial.Contracts.Requests;
using EndpointsTutorial.Contracts.Responses;
using EndpointsTutorial.Models;
using FastEndpoints;

namespace EndpointsTutorial.Mappers
{
    public class WeatherForecastMapper :
        Mapper<WeatherForecastRequest, WeatherForecastResponse, WeatherForecast>
    {
        public override WeatherForecastResponse FromEntity(WeatherForecast e)
        {
            return new WeatherForecastResponse
            {
                Date = e.Date,
                Summary = e.Summary,
                TemperatureC = e.TemperatureC,
                TemperatureF = e.TemperatureF
            };
        }
    }
}
