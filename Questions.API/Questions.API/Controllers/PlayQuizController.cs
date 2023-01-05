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

        [HttpGet]
        public async Task<ActionResult<PlayQuizQuestion>> GetPlayQuizQuestionAsync()
        {
            var playQuizQuestion = await _quizPlayService.GetPlayQuizQuestion();
            return playQuizQuestion == null ?  NotFound() : Ok(playQuizQuestion);
        }

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