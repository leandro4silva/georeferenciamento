using FluentValidation.AspNetCore;
using Georeferenciamento.Api.Filters;
using Georeferenciamento.Api.Middlewares;
using Georeferenciamento.Application;
using Georeferenciamento.Infra;
using Georeferenciamento.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

var appConfigs = builder.AddAppConfigs();

builder.Services.AddApplication();
builder.Services.AddRepositories(appConfigs);
builder.Services.AddControllers(options =>
        options.Filters.Add(typeof(ExceptionFilter)))
    .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ValidationMiddleware>();

app.MapControllers();

app.Run();
