using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Questions.API.Models.DTO;
using Questions.API.Repositories;
using Questions.API.Services;

namespace Questions.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]

    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;

        public AnswerController(IAnswerService answerService, IMapper mapper, IValidationService validationService)
        {
            _answerService = answerService;
            _mapper = mapper;
            _validationService = validationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnsDto>>> GetAllAnswersAsync()
        {
            var allAnswers = await _answerService.GetAllAnswersAsync();
            return (allAnswers == null) ? NotFound() : Ok(allAnswers);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetAnswerAsync")]
        public async Task<ActionResult<AnsDto>> GetAnswerAsync(Guid id)
        {
            var specificAnswer = await _answerService.GetAnswerAsync(id);
            return (specificAnswer == null) ? NotFound() : Ok(specificAnswer);
        }

        [HttpPost]
        public async Task<ActionResult<AnsDto>> AddAnswerAsync([FromBody] Models.DTO.AddAnsRequestDto addAnswerRequestDto)
        {
            if (!_validationService.ValidateAddAnswerAsync(ModelState, addAnswerRequestDto))
            {
                return BadRequest(ModelState);
            }

            var addedAnswer = await _answerService.AddAnswerAsync(addAnswerRequestDto);
            return (addedAnswer == null) ?
                NotFound() :
                CreatedAtAction(nameof(GetAnswerAsync), new { id = addedAnswer.Id }, addedAnswer);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<AnsDto>> UpdateAnswerAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateAnsRequestDto updateAnsRequestDto)
        {
            if (!_validationService.ValidateUpdateAnswerAsync(ModelState, updateAnsRequestDto))
            {
                return BadRequest(ModelState);
            }

            var updatedAnswer = await _answerService.UpdateAnswerAsync(id, updateAnsRequestDto);
            return (updatedAnswer == null) ? NotFound() : Ok(updatedAnswer);
        }

        // DELETE: api/v1/Questions/id
        /// <summary>
        /// Deletes Question with specified Guid Id.
        /// </summary>
        /// <param name="id"> ID of the question to delete.</param>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<AnsDto>> DeleteAnswerAsync(Guid id)
        {
            var deletedAnswer = await _answerService.DeleteAnswerAsync(id);
            return (deletedAnswer == null) ? NotFound() : Ok(deletedAnswer);
        }

    }
}


