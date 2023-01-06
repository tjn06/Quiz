using System;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Questions.API.Models.DTO
{
	public class AddQnRequestDto : IValidatableObject
    {
        [Required]
        public string? Language { get; set; }
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? Category { get; set; }

        // Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Language != "English" && Language != "Swedish")
            {
                 yield return new ValidationResult("Language must be in English or Swedish", new[] { "Language string" });
            }
            if (Question == "string" )
            {
                yield return new ValidationResult("Question-default-value(string) is not a question",  new[] { "Question string" });
            }
            if (Question != null && Question.Substring(Question.Length - 1) != "?")
            {
                yield return new ValidationResult("Question must end with a question-mark(?)", new[] { "Question string" });
            }
        }
    }
}

