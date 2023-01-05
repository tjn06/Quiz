using System;
using System.ComponentModel.DataAnnotations;

namespace Questions.API.Models.DTO
{
	public class CheckPlayQuizAnsRequest
	{
        [Required]
        public Guid AnswerId { get; set; }
    }
}

