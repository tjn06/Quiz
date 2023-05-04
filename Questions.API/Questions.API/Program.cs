using Microsoft.EntityFrameworkCore;
using Questions.API.Controllers;
using Questions.API.Percistanse;
using Questions.API.Repositories;
using Questions.API.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.ComponentModel;
using Questions.API.Configurations;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration;

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        builder.Services.AddSwaggerConfigurations();
        builder.Services.AddQuizDBContext();
        builder.Services.AddDependencyInjections(config);
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        RunWebApplication(builder);
    }

    static void RunWebApplication(WebApplicationBuilder builder)
    {
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
    }
}
