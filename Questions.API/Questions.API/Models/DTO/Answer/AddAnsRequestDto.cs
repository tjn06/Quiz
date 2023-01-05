using System;
using System.ComponentModel.DataAnnotations;

namespace Questions.API.Models.DTO
{
	public class AddAnsRequestDto
	{
        [Required]
        public Guid QuestionId { get; set; }
        [Required]
        public string? Answer { get; set; }
        [Required]
        public bool IsCorrectAnswer { get; set; }
    }
}

