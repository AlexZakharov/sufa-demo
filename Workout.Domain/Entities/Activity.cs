namespace Workout.Domain.Entities;

public class Activity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
}