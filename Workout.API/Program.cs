using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Workout.Data;
using Workout.Features.Activities.CreateActivity;
using Workout.Features.Activities.GetActivity;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext (in-memory for dev/testing)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TestDb"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCreateActivity();
app.MapGetActivity();

app.Run();