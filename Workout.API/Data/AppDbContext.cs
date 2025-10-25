using Microsoft.EntityFrameworkCore;
using Workout.Domain.Entities;

namespace Workout.Data;

public class AppDbContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optional configurations
        base.OnModelCreating(modelBuilder);
    }
}