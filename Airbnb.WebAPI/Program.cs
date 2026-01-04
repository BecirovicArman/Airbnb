using Airbnb.Application;
using Airbnb.Infrastructure;
using Airbnb.Infrastructure.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ConflictExceptionHandler>();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseAuthorization();
app.MapControllers();

app.Run();