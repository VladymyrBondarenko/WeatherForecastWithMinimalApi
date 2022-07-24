using EndpointsTutorial.Contracts.Requests;
using FastEndpoints;
using FluentValidation;

namespace EndpointsTutorial.Validators
{
    public class WeatherForecastRetrievalValidator : 
        Validator<WeatherForecastRequest>
    {
        public WeatherForecastRetrievalValidator()
        {
            RuleFor(i => i.Days)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Weather forecast days must be at least 1")
                .LessThanOrEqualTo(14)
                .WithMessage("Weather forecast can't be retrieved past 14 days");
        }
    }
}
