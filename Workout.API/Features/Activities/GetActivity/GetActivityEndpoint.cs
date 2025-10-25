using MediatR;
using Workout.Exceptions;

namespace Workout.Features.Activities.GetActivity;

public static class GetActivityEndpoint
{
    public static void MapGetActivity(this IEndpointRouteBuilder app)
    {
        app.MapGet("/activities/{id:guid}", async (Guid id, ISender sender) =>
            {
                try
                {
                    var response = await sender.Send(new GetActivityQuery(id));
                    return Results.Ok(response);
                }
                catch (NotFoundException)
                {
                    return Results.NotFound();
                }
            })
            .WithName("GetActivity")
            .Produces<GetActivityResponse>(200)
            .ProducesProblem(404);
    }
}