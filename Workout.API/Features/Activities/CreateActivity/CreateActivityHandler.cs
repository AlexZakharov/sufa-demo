using MediatR;
using Workout.Data;
using Workout.Domain.Entities;

namespace Workout.Features.Activities.CreateActivity;

public class CreateActivityHandler(AppDbContext dbContext)
    : IRequestHandler<CreateActivityCommand, CreateActivityResponse>
{
    public async Task<CreateActivityResponse> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = new Activity { Name = request.Name, Date = request.Date, Duration = request.Duration };
        dbContext.Activities.Add(activity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateActivityResponse(activity.Id);
    }
}