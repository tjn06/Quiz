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
    //[ApiController]
    //[Route("[controller]")]

    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]

    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;


        public AnswerController(IAnswerService answerService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnswersAsync()
        {
            var allAnswers = await _answerService.GetAllAnswersAsync();
            return (allAnswers == null) ? NotFound() : Ok(allAnswers);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetAnswerAsync")]
        public async Task<IActionResult> GetAnswerAsync(Guid id)
        {
            var specificAnswer = await _answerService.GetAnswerAsync(id);
            return (specificAnswer == null) ? NotFound() : Ok(specificAnswer);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswerAsync([FromBody] Models.DTO.AddAnsRequestDto addAnswerRequestDto)
        {
            // Custom validation
            // if (!_validationService.ValidateAddAnswerAsync(ModelState,addAnswerRequestDto))
            //{
            //    return BadRequest(ModelState);
            //}

            var addedAnswer = await _answerService.AddAnswerAsync(addAnswerRequestDto);

            return (addedAnswer == null) ?
                NotFound() :
                CreatedAtAction(nameof(GetAnswerAsync), new { id = addedAnswer.Id }, addedAnswer);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAnswerAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateAnsRequestDto updateAnsRequestDto)
        {
            var updatedAnswer = await _answerService.UpdateAnswerAsync(id, updateAnsRequestDto);
            return (updatedAnswer == null) ? NotFound() : Ok(updatedAnswer);
        }

        // DELETE: api/v2/Questions/id
        /// <summary>
        /// Deletes Question with specified Guid Id.
        /// </summary>
        /// <param name="id"> ID of the question to delete.</param>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAnswerAsync(Guid id)
        {
            var deletedAnswer = await _answerService.DeleteAnswerAsync(id);
            return (deletedAnswer == null) ? NotFound() : Ok(deletedAnswer);
        }
    }
}