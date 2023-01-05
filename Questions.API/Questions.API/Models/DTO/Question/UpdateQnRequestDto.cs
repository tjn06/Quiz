﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Questions.API.Models.DTO
{
	public class UpdateQnRequestDto
	{
        public string? Language { get; set; }
        [Required]
        public string? Question { get; set; }
        public string? Category { get; set; }
    }
}

