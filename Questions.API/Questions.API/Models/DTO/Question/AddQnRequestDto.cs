using System;
namespace Questions.API.Models.DTO
{
	public class AddQnRequestDto
    {
        public string Language { get; set; }
        public string Question { get; set; }
        public string Category { get; set; }
    }
}

