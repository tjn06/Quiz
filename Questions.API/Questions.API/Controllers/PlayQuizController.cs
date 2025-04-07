using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questions.API.Models.Entities;
using Questions.API.Services;

namespace Questions.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PlayQuizController : Controller
    {
        private readonly IQuizPlayService _quizPlayService;

        public PlayQuizController( IQuizPlayService quizPlayService)
        {
            _quizPlayService = quizPlayService;
        }

        /// <summary>
        /// Get a random question with answers, use the answer-id:s to answer the question
        /// </summary>
        /// <response code="200">Returns a question with belonging answers</response>       
        /// <response code="404">No question was provided</response>  
        [HttpGet]
        public async Task<ActionResult<PlayQuizQuestion>> GetPlayQuizQuestionAsync()
        {
            var playQuizQuestion = await _quizPlayService.GetPlayQuizQuestion();
            return playQuizQuestion == null ?  NotFound() : Ok(playQuizQuestion);
        }

        /// <summary>
        /// Add a question-ID and an answer-ID related to the question to check answer
        /// </summary>
        /// <response code="200">Returns answer is correct/incorrect or question/answer-id is found/not found or question-answer is not related</response>
        [HttpPut]
        [Route("{questionId:guid}")]
        public async Task<ActionResult<string>> CheckAnswerAsync([FromRoute] Guid questionId,
            [FromBody] Models.DTO.CheckPlayQuizAnsRequest checkPlayQuizAnsRequest)
        {
            var selectedAnswerReply = await _quizPlayService.GetPlayQuizAnswerCorrectionReply(questionId, checkPlayQuizAnsRequest.AnswerId);
            return Ok(selectedAnswerReply);
        }
    }
}