using System;
using System.ComponentModel.DataAnnotations;
using Questions.API.Models.Entities;

namespace Questions.API.Models.DTO
{
	public class AnsDto
	{
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid QuestionId { get; set; }
        [Required]
        public string? Answer { get; set; }
        [Required]
        public bool IsCorrectAnswer { get; set; }
    }
}

