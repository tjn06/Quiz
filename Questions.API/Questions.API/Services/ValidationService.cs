using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Questions.API.Models.DTO;

namespace Questions.API.Services
{
	public class ValidationService
	{
        internal bool ValidateAddAnswerAsync(
            ModelStateDictionary ModelState,
            Models.DTO.AddAnsRequestDto addAnswerRequestDto)
        {
            if (addAnswerRequestDto == null)
            {
                ModelState.AddModelError(nameof(addAnswerRequestDto),
                    $"Request Data is required.");
                return false;
            }
            if (addAnswerRequestDto.QuestionId == Guid.Empty)
            {
                ModelState.AddModelError(nameof(addAnswerRequestDto.QuestionId),
                    $"QuestionId is required");
                return false;
            }
            if (string.IsNullOrWhiteSpace(addAnswerRequestDto.Answer))
            {
                ModelState.AddModelError(nameof(addAnswerRequestDto.Answer),
                    $"{nameof(addAnswerRequestDto.Answer)} cannot be null, empty or white space");
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }
    }
}

