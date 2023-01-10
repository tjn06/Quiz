using System;
using System.ComponentModel.DataAnnotations;

namespace Questions.API.Models.DTO
{

    
	public class UpdateAnsRequestDto //: IValidatableObject
    {
        [Required]
        public Guid QuestionId { get; set; }
        [Required]
        public string? Answer { get; set; }
        [Required]
        public bool IsCorrectAnswer { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (item == "")
        //    {
        //        yield return new ValidationResult("Item is invalid", new[] { "ItemId" });
        //    }
        //}
    }
}

