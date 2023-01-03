using Microsoft.EntityFrameworkCore;
using Questions.API.Controllers;
using Questions.API.Data;
using Questions.API.Repositories;
using Questions.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NZWalksDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency injections
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IWalkDifficultyRepository, WalkDifficultyRepository>();
builder.Services.AddScoped<ITriviaRepository, TriviaRepository>();
builder.Services.AddScoped<IQuizPlayService, QuizPlayService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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

