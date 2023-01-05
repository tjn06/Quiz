using System;
using System.ComponentModel.DataAnnotations;

namespace Questions.API.Models.DTO
{
	public class AnsPlayQuizDto
	{
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Answer { get; set; }
    }
}

