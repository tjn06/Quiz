using System;
namespace Questions.API.Models.Domain
{
	public class Ans
	{
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string? Answer { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}

