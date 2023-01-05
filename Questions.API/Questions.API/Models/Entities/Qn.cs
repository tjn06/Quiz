using System;
using System.ComponentModel.DataAnnotations;

namespace Questions.API.Models.Entities
{
	public class Qn
	{
        [Required]
        public Guid Id { get; set; }
        public string? Language { get; set; }
        [Required]
        public string? Question { get; set; }
        public string? Category { get; set; }
    }
}

