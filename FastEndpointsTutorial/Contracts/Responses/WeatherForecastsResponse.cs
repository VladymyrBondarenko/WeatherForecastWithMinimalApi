namespace EndpointsTutorial.Contracts.Responses
{
    public class WeatherForecastsResponse
    {
        public IEnumerable<WeatherForecastResponse>? WeatherForecasts { get; set; }
    }
}
