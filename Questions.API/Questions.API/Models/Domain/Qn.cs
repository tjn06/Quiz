using System;
namespace Questions.API.Models.Domain
{
	public class Qn
	{
        public Guid Id { get; set; }
        public string Language { get; set; }
        public string Question { get; set; }
        public string Category { get; set; }
    }
}

