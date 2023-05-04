using Microsoft.AspNetCore.Mvc.ModelBinding;
using Questions.API.Models.DTO;

namespace Questions.API.Services
{
    // Code experiment validate requestobject , not in use
    public interface IValidationService
    {
        bool ValidateAddAnswerAsync(ModelStateDictionary ModelState, AddAnsRequestDto addAnswerRequestDto);
        bool ValidateUpdateAnswerAsync(ModelStateDictionary ModelState, UpdateAnsRequestDto updateAnsRequestDto);
    }
}