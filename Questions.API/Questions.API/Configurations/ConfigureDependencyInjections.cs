using System;
using Questions.API.Repositories;
using Questions.API.Services;

namespace Questions.API.Configurations
{
	public static class ConfigureDependencyInjections
	{
		public static IServiceCollection AddDependencyInjections(this IServiceCollection services, ConfigurationManager config)
		{
            return services
            .AddScoped<IQuestionRepository, QuestionRepository>()
            .AddScoped<IAnswerRepository, AnswerRepository>()
            .AddScoped<ITriviaRepository, TriviaRepository>()
            .AddScoped<IQuizPlayService, QuizPlayService>()
            .AddScoped<IAnswerService, AnswerService>()
            .AddScoped<IQuestionService, QuestionService>()
            .AddScoped<IValidationService, ValidationService>();
        }
	}
}

