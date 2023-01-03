using System;
using Questions.API.Models.DTO;

namespace Questions.API.Models.Domain
{
    public class PlayQuizQuestion
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Category { get; set; }
        public List<AnsPlayQuizDto> Answers {get;set;}

        public PlayQuizQuestion()
        {
            Answers = new List<AnsPlayQuizDto>();
        }
    }

}

