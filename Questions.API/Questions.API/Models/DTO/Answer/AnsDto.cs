using System;
using Questions.API.Models.Domain;

namespace Questions.API.Models.DTO
{
	public class AnsDto
	{
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string? Answer { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}

