using MediatR;

namespace Workout.Features.Activities.GetActivity;

public record GetActivityQuery(Guid Id) : IRequest<GetActivityResponse>;