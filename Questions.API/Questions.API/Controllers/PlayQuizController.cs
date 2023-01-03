using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questions.API.Models.Domain;
using Questions.API.Services;

namespace Questions.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PlayQuizController : Controller
    {
        private readonly IQuizPlayService quizPlayService;

        public PlayQuizController( IQuizPlayService quizPlayService)
        {
            this.quizPlayService = quizPlayService;
        }


        [HttpGet]
        public async Task<ActionResult<PlayQuizQuestion>> GetPlayQuizQuestionAsync()
        {
            var playQuizQuestion = await quizPlayService.GetPlayQuizQuestion();
            return playQuizQuestion != null ? Ok(playQuizQuestion) : NotFound();
        }


        [HttpPut]
        [Route("{questionId:guid}")]
        public async Task<ActionResult<string>> CheckAnswerAsync([FromRoute] Guid questionId,
            [FromBody] Models.RequstBody.CheckPlayQuizAnsRequest checkPlayQuizAnsRequest)
        {
            var selectedAnswerReply = await quizPlayService.GetPlayQuizAnswerCorrectionReply(questionId, checkPlayQuizAnsRequest.AnswerId);
            return Ok(selectedAnswerReply);
        }



    }
}