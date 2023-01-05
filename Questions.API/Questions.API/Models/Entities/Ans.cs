using System;
using System.ComponentModel.DataAnnotations;

namespace Questions.API.Models.Entities
{
	public class Ans
	{
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string? Answer { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}

