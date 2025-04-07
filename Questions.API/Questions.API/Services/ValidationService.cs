using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Questions.API.Models.DTO;

namespace Questions.API.Services
{
    public class ValidationService : IValidationService
    {
        public bool ValidateAddAnswerAsync(
        ModelStateDictionary ModelState,
        Models.DTO.AddAnsRequestDto addAnswerRequestDto)
        {
            if (addAnswerRequestDto.QuestionId == Guid.Empty)
            {
                ModelState.AddModelError(nameof(addAnswerRequestDto.QuestionId),
                    $"QuestionId is required");
                return false;
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }

        public bool ValidateUpdateAnswerAsync(
        ModelStateDictionary ModelState,
        Models.DTO.UpdateAnsRequestDto updateAnsRequestDto)
        {
            if (updateAnsRequestDto.QuestionId == Guid.Empty)
            {
                ModelState.AddModelError(nameof(updateAnsRequestDto.QuestionId),
                    $"AnswerId is required");
                return false;
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }

    }
}

