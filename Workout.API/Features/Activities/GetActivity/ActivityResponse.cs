namespace Workout.Features.Activities.GetActivity;

public record GetActivityResponse(Guid Id, string Name, DateTime Date, int Duration);