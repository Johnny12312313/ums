using System.Reflection;
using MediatR;
using MediatR.Pipeline;
using WebApplicationDB.Middleware;
using WebApplicationDB.Models;
using WebApplicationDB.User;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
var connectionString = "connection string to database";

builder.Services.AddDbContext<postgresContext>(ServiceLifetime.Scoped);



builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AppLoggingBehaviour<,>));

    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();