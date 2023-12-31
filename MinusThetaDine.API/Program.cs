using Microsoft.AspNetCore.Mvc.Infrastructure;
using MinusTheta.Application;
using MinusTheta.Infrastructure;
using MinusThetaDine.API.Error;
using MinusThetaDine.API.Filters;
using MinusThetaDine.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddSingleton<ProblemDetailsFactory,MinusThetaProblemDetailsFactory>();
var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        //app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}