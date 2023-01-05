using System;
using System.ComponentModel.DataAnnotations;
using Questions.API.Models.DTO;

namespace Questions.API.Models.Entities
{
    public class PlayQuizQuestion
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Question { get; set; }
        public string? Category { get; set; }
        public List<AnsPlayQuizDto> Answers {get;set;}

        public PlayQuizQuestion()
        {
            Answers = new List<AnsPlayQuizDto>();
        }
    }

}

