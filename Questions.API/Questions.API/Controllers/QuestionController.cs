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
        /// Ass summary here
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<QnDto>>> GetAllQuestionAsync()
        {
            var allQuestions = await _questionService.GetAllQuestionsAsync();
            return (allQuestions == null) ? NotFound() : Ok(allQuestions);
        }

        /// <summary>
        /// Ass summary here
        /// </summary>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetQuestionAsync")]
        public async Task<ActionResult<QnDto>> GetQuestionAsync(Guid id)
        {
            var question = await _questionService.GetQuestionAsync(id);
            return (question == null) ? NotFound() : Ok(question);
        }

        /// <summary>
        /// Ass summary here
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<QnDto>> AddQuestionAsync(Models.DTO.AddQnRequestDto addQnRequestDto)
        {
            try
            {
                if (addQnRequestDto == null)
                {
                    return BadRequest("Update object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var addedQuestion = await _questionService.AddQuestionAsync(addQnRequestDto);

                return (addedQuestion == null) ?
                    NotFound() :
                    CreatedAtAction(nameof(GetQuestionAsync), new { id = addedQuestion.Id }, addedQuestion);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside the CreateOwner action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Ass summary here
        /// </summary>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<QnDto>> UpdateQuestionAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateQnRequestDto updateQnRequestDto)
        {
            try
            {
                if (updateQnRequestDto == null)
                {
                    return BadRequest("Update object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
 
                var updatedQuestion = await _questionService.UpdateQuestionAsync(id, updateQnRequestDto);
       
                return (updatedQuestion == null) ?
                    NotFound() :
                    CreatedAtAction(nameof(GetQuestionAsync), new { id = updatedQuestion.Id }, updatedQuestion);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside the CreateOwner action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Ass summary here
        /// </summary>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<QnDto>> DeleteQuestionAsync(Guid id)
        {
            var deletedQuestion = await _questionService.DeleteQuestionAsync(id);
            return (deletedQuestion == null) ? BadRequest() : Ok(deletedQuestion);
        }
    }

}


