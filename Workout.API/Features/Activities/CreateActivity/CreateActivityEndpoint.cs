using FluentValidation;
using MediatR;

namespace Workout.Features.Activities.CreateActivity;

public static class CreateActivityEndpoint
{
    public static void MapCreateActivity(this IEndpointRouteBuilder app)
    {
        app.MapPost("/activities", async (CreateActivityCommand command, ISender sender, IValidator<CreateActivityCommand> validator) =>
        {
            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);
            var response = await sender.Send(command);
            return Results.Created($"/activities/{response.Id}", response);
        });
    }
}