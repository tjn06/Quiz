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
        /// Ass summary here
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnsDto>>> GetAllAnswersAsync()
        {
            var allAnswers = await _answerService.GetAllAnswersAsync();
            return (allAnswers == null) ? NotFound() : Ok(allAnswers);
        }

        /// <summary>
        /// Ass summary here
        /// </summary>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetAnswerAsync")]
        public async Task<ActionResult<AnsDto>> GetAnswerAsync(Guid id)
        {
            var specificAnswer = await _answerService.GetAnswerAsync(id);
            return (specificAnswer == null) ? NotFound() : Ok(specificAnswer);
        }

        /// <summary>
        /// Ass summary here
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<AnsDto>> AddAnswerAsync([FromBody] Models.DTO.AddAnsRequestDto addAnswerRequestDto)
        {

            var addedAnswer = await _answerService.AddAnswerAsync(addAnswerRequestDto);
            return (addedAnswer == null) ?
                NotFound() :
                CreatedAtAction(nameof(GetAnswerAsync), new { id = addedAnswer.Id }, addedAnswer);
        }

        /// <summary>
        /// Ass summary here
        /// </summary>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<AnsDto>> UpdateAnswerAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateAnsRequestDto updateAnsRequestDto)
        {
            var updatedAnswer = await _answerService.UpdateAnswerAsync(id, updateAnsRequestDto);
            return (updatedAnswer == null) ? NotFound() : Ok(updatedAnswer);
        }

        /// <summary>
        /// Creates a Answer item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Answer
        ///     {
        ///        "id": "",
        ///        "": "",
        ///        "": ""
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>A newly created Answer item</returns>
        /// <response code="201">Returns the deleted item</response>       
        /// <response code="404">Item to delete not found</response>  
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<AnsDto>> DeleteAnswerAsync(Guid id)
        {
            var deletedAnswer = await _answerService.DeleteAnswerAsync(id);
            return (deletedAnswer == null) ? NotFound() : Ok(deletedAnswer);
        }

    }
}


//if (!_validationService.ValidateUpdateAnswerAsync(ModelState, updateAnsRequestDto))
//{
//    return BadRequest(ModelState);
//}