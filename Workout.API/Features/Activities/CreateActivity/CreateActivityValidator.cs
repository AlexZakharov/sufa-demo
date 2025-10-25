using FluentValidation;

namespace Workout.Features.Activities.CreateActivity;

public class CreateActivityValidator : AbstractValidator<CreateActivityCommand>
{
    public CreateActivityValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Duration).GreaterThan(0);
    }
}