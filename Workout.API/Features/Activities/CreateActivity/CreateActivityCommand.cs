using MediatR;

namespace Workout.Features.Activities.CreateActivity;

public record CreateActivityCommand(string Name, DateTime Date, int Duration) : IRequest<CreateActivityResponse>;