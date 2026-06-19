using AromaCraft.Api.Infrastructure;
using AromaCraft.Application;
using AromaCraft.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // app.UseSwaggerUI(options =>
    // {
    //     options.SwaggerEndpoint("/openapi/v1.json", "v1");
    // });

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();


app.Run();
