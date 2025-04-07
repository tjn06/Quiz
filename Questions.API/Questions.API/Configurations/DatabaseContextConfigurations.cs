using System;
using Microsoft.EntityFrameworkCore;
using Questions.API.Percistanse;

namespace Questions.API.Configurations
{
	public static class DatabaseContextConfigurations
	{
		public static IServiceCollection AddQuizDBContext(this IServiceCollection services, string fileName = "quizdb.db")
		{
            return services
            .AddDbContext<QuizDBContext>(options =>
                options.UseSqlite($"Data Source={fileName}"),
                ServiceLifetime.Scoped
            );

        }

	}
}

