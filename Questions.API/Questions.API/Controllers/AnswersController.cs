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
using Swashbuckle.AspNetCore.Annotations;



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

        /// <summary>
        /// Get all Answer-items
        /// </summary>
        /// <response code="200">Returns all answers</response>       
        /// <response code="404">Answers was not found</response>  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<AnsDto>>> GetAllAnswersAsync()
        {
            var allAnswers = await _answerService.GetAllAnswersAsync();
            return (allAnswers == null) ? NotFound() : Ok(allAnswers);
        }

        /// <summary>
        /// Get a specific Answer-item
        /// </summary>
        /// <param name="id">Answer-ID to get</param>
        /// <response code="200">Returns the requsted answer</response>       
        /// <response code="404">Answer was not found</response>  
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetAnswerAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<ActionResult<AnsDto>> GetAnswerAsync(Guid id)
        {
            var specificAnswer = await _answerService.GetAnswerAsync(id);
            return (specificAnswer == null) ? NotFound() : Ok(specificAnswer);
        }

        /// <summary>
        /// Add an Answer-item
        /// </summary>
        /// <param name="addAnswerRequestDto">Answer-values to add</param>
        /// <response code="201">Returns the added answer</response>       
        /// <response code="404">Answer was not added</response>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json")]
        public async Task<ActionResult<AnsDto>> AddAnswerAsync([FromBody] Models.DTO.AddAnsRequestDto addAnswerRequestDto)
        {
            var addedAnswer = await _answerService.AddAnswerAsync(addAnswerRequestDto);
            return (addedAnswer == null) ?
                NotFound() :
                CreatedAtAction(nameof(GetAnswerAsync), new { id = addedAnswer.Id }, addedAnswer);
        }

        /// <summary>
        /// Update an Answer-item
        /// </summary>
        /// <param name="id">Answer-ID to update</param>
        /// <param name="updateAnsRequestDto">Answer-values to update</param>
        /// <response code="200">Returns the deleted answer</response>       
        /// <response code="404">Answer to update not found</response>  
        [HttpPut]
        [Route("{id:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AnsDto>> UpdateAnswerAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateAnsRequestDto updateAnsRequestDto)
        {
            var updatedAnswer = await _answerService.UpdateAnswerAsync(id, updateAnsRequestDto);
            return (updatedAnswer == null) ? NotFound() : Ok(updatedAnswer);
        }

        /// <summary>
        /// Delete an Answer-item
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Returns the deleted answer</response>       
        /// <response code="404">Answer to delete not found</response>  
        [HttpDelete]
        [Route("{id:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AnsDto>> DeleteAnswerAsync(Guid id)
        {
            var deletedAnswer = await _answerService.DeleteAnswerAsync(id);
            return (deletedAnswer == null) ? NotFound() : Ok(deletedAnswer);
        }

    }
}

// Experimental, not in use

//if (!_validationService.ValidateUpdateAnswerAsync(ModelState, updateAnsRequestDto))
//{
//    return BadRequest(ModelState);
//}