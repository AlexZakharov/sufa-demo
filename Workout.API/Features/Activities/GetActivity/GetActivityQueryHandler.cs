using MediatR;
using Microsoft.EntityFrameworkCore;
using Workout.Data;
using Workout.Exceptions;

namespace Workout.Features.Activities.GetActivity;

public class GetActivityQueryHandler(AppDbContext dbContext) : IRequestHandler<GetActivityQuery, GetActivityResponse>
{
    public async Task<GetActivityResponse> Handle(GetActivityQuery request, CancellationToken cancellationToken)
    {
        var activity = await dbContext.Activities.AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        return activity == null 
            ? throw new NotFoundException($"Activity with ID {request.Id} not found.") 
            : new GetActivityResponse(activity.Id, activity.Name, activity.Date, activity.Duration);
    }
}