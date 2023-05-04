using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Questions.API.Models.Entities;
using Questions.API.Models.DTO;
using Questions.API.Repositories;
using Questions.API.Services;

namespace Questions.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Question-items
        /// </summary>
        /// <response code="200">Returns all question</response>       
        /// <response code="404">Questions was not found</response>  
        [HttpGet]
        public async Task<ActionResult<List<QnDto>>> GetAllQuestionAsync()
        {
            var allQuestions = await _questionService.GetAllQuestionsAsync();
            return (allQuestions == null) ? NotFound() : Ok(allQuestions);
        }

        /// <summary>
        /// Get a specific Question-item
        /// </summary>
        /// <param name="id">Question-ID to get</param>
        /// <response code="200">Returns the requsted question</response>       
        /// <response code="404">Question was not found</response>  
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetQuestionAsync")]
        public async Task<ActionResult<QnDto>> GetQuestionAsync(Guid id)
        {
            var question = await _questionService.GetQuestionAsync(id);
            return (question == null) ? NotFound() : Ok(question);
        }

        /// <summary>
        /// Add a Question-item
        /// </summary>
        /// <param name="addQnRequestDto">Question-values to add</param>
        /// <response code="201">Returns the added question</response>       
        /// <response code="404">Question was not added</response>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<QnDto>> AddQuestionAsync(Models.DTO.AddQnRequestDto addQnRequestDto)
        {
            var addedQuestion = await _questionService.AddQuestionAsync(addQnRequestDto);

            return (addedQuestion == null) ?
                NotFound() :
                CreatedAtAction(nameof(GetQuestionAsync), new { id = addedQuestion.Id }, addedQuestion);
        }

        /// <summary>
        /// Update a Question-item
        /// </summary>
        /// <param name="id">Question-ID to update</param>
        /// <param name="updateQnRequestDto">Question-values to update</param>
        /// <response code="200">Returns the deleted question</response>       
        /// <response code="404">Question to update not found</response>  
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<QnDto>> UpdateQuestionAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateQnRequestDto updateQnRequestDto)
        {
            var updatedQuestion = await _questionService.UpdateQuestionAsync(id, updateQnRequestDto);

            return (updatedQuestion == null) ?
                NotFound() :
                Ok(updatedQuestion);
        }

        /// <summary>
        /// Delete a Question-item
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Returns the deleted question</response>       
        /// <response code="404">Question to delete not found</response>  
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<QnDto>> DeleteQuestionAsync(Guid id)
        {
            var deletedQuestion = await _questionService.DeleteQuestionAsync(id);
            return (deletedQuestion == null) ? BadRequest() : Accepted(deletedQuestion);
        }
    }

}


