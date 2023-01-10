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
        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        builder.Services.AddSwaggerConfigurations();

        //builder.Services.AddSwaggerGen(options =>
        //{
        //    options.SwaggerDoc("v1", new OpenApiInfo
        //    {
        //        Version = "v1",
        //        Title = "QuizApi",
        //        Description = "QuizApi",
        //        TermsOfService = new Uri("https://example.com/terms"),
        //        Contact = new OpenApiContact
        //        {
        //            Name = "TJ && HH",
        //            Url = new Uri("https://example.com/contact")
        //        },
        //        License = new OpenApiLicense
        //        {
        //            Name = "License",
        //            Url = new Uri("https://example.com/license")
        //        }
        //    });
        //});


        //builder.Services.AddSwaggerGen(c =>
        //{
        //    // Set the comments path for the Swagger JSON and UI.
        //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //    c.IncludeXmlComments(xmlPath);
        //});

        //builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();

        //builder.Services.AddDbContext<QuizDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddQuizDBContext();
        builder.Services.AddDependencyInjections(config);
        // Dependency injections
        //builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
        //builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
        //builder.Services.AddScoped<ITriviaRepository, TriviaRepository>();
        //builder.Services.AddScoped<IQuizPlayService, QuizPlayService>();
        //builder.Services.AddScoped<IAnswerService, AnswerService>();
        //builder.Services.AddScoped<IQuestionService, QuestionService>();
        //builder.Services.AddScoped<IValidationService, ValidationService>();
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

















//using Microsoft.EntityFrameworkCore;
//using Questions.API.Controllers;
//using Questions.API.Percistanse;
//using Questions.API.Repositories;
//using Questions.API.Services;
//using Microsoft.OpenApi.Models;
//using System.Reflection;


//    // Add services to the container.
//    builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Version = "v1",
//        Title = "QuizApi",
//        Description = "QuizApi",
//        TermsOfService = new Uri("https://example.com/terms"),
//        Contact = new OpenApiContact
//        {
//            Name = "TJ && HH",
//            Url = new Uri("https://example.com/contact")
//        },
//        License = new OpenApiLicense
//        {
//            Name = "License",
//            Url = new Uri("https://example.com/license")
//        }
//    });
//});

//builder.Services.AddSwaggerGen(c =>
//{
//    // Set the comments path for the Swagger JSON and UI.
//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    c.IncludeXmlComments(xmlPath);
//});

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<QuizDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Dependency injections
//builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
//builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
//builder.Services.AddScoped<ITriviaRepository, TriviaRepository>();
//builder.Services.AddScoped<IQuizPlayService, QuizPlayService>();
//builder.Services.AddScoped<IAnswerService, AnswerService>();
//builder.Services.AddScoped<IQuestionService, QuestionService>();
//builder.Services.AddScoped<IValidationService, ValidationService>();
//builder.Services.AddAutoMapper(typeof(Program).Assembly);

//var app = builder.Build();


//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

