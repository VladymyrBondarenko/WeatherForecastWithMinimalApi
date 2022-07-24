using EndpointsTutorial.Contracts.Requests;
using EndpointsTutorial.Contracts.Responses;
using EndpointsTutorial.Mappers;
using EndpointsTutorial.Models;
using FastEndpoints;

namespace EndpointsTutorial.Contracts.Endpoints
{
    public class WeatherForecastEndpoint : 
        Endpoint<WeatherForecastRequest, WeatherForecastsResponse, WeatherForecastMapper>
    {
        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmys"
        };

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("weather/{days}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(WeatherForecastRequest req, CancellationToken ct)
        {
            var forecasts = Enumerable.Range(1, req.Days)
                .Select(i => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();

            var response = new WeatherForecastsResponse
            {
                WeatherForecasts = forecasts.Select(Map.FromEntity)
            };

            await SendAsync(response, cancellation: ct);
        }
    }
}
