using Microsoft.AspNetCore.Mvc.ModelBinding;
using Questions.API.Models.DTO;

namespace Questions.API.Services
{
    public interface IValidationService
    {
        bool ValidateAddAnswerAsync(ModelStateDictionary ModelState, AddAnsRequestDto addAnswerRequestDto);
        bool ValidateUpdateAnswerAsync(ModelStateDictionary ModelState, UpdateAnsRequestDto updateAnsRequestDto);
    }
}