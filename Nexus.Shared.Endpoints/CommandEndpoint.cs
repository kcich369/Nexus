using MediatR;
using Microsoft.AspNetCore.Builder;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Mediator;
using Microsoft.AspNetCore.Routing;
using Nexus.Shared.Mediator.Cqrs;

namespace Nexus.Shared.Endpoints;

public abstract class CommandEndpoint<TCommand, TResult> where TCommand : ICommand<IResult<TResult>>
{
    private readonly IMediator _mediator;

    // public CommandEndpoint(IMediator mediator)
    // {
    //     _mediator = mediator;
    // }

    protected CommandEndpoint()
    {
    }

    public async Task Handle(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/weatherforecast", async (TCommand command, IMediator mediator, CancellationToken ct) =>
        {
            var result = await _mediator.Send(command, ct);
           return result.IsError ? "IsError" : "Success";
        });
    }

    // public void Handle2(IEndpointRouteBuilder app)
    // {
    //     var summaries = new[]
    //     {
    //         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //     };
    //
    //     app.MapGet("/weatherforecast", () =>
    //         {
    //             var forecast = Enumerable.Range(1, 5).Select(index =>
    //                     new WeatherForecast
    //                     (
    //                         DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //                         Random.Shared.Next(-20, 55),
    //                         summaries[Random.Shared.Next(summaries.Length)]
    //                     ))
    //                 .ToArray();
    //             return forecast;
    //         })
    //         .WithName("GetWeatherForecast")
    //         .WithOpenApi();
    // }

    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}