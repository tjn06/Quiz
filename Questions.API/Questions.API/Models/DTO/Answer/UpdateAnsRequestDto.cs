using System;
namespace Questions.API.Models.DTO
{
	public class UpdateAnsRequestDto
	{
        public Guid QuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}

