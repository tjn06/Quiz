using System;
namespace Questions.API.Models.DTO
{
	public class QnDto
	{
        public Guid Id { get; set; }
        public string Language { get; set; }
        public string Question { get; set; }
        public string Category { get; set; }
    }
}

