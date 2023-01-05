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
    //[ApiController]
    //[Route("[controller]")]

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


        [HttpGet]
        public async Task<IActionResult> GetAllQuestionAsync()
        {
            var allQuestions = await _questionService.GetAllQuestionsAsync();
            return (allQuestions == null) ? NotFound() : Ok(allQuestions);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetQuestionAsync")]
        public async Task<IActionResult> GetQuestionAsync(Guid id)
        {
            var question = await _questionService.GetQuestionAsync(id);
            return (question == null) ? NotFound() : Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestionAsync(Models.DTO.AddQnRequestDto addQnRequestDto)
        {
            var addedQuestion = await _questionService.AddQuestionAsync(addQnRequestDto);
            return (addedQuestion == null) ?
                NotFound() :
                CreatedAtAction(nameof(GetQuestionAsync), new { id = addedQuestion.Id }, addedQuestion);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateQuestionAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateQnRequestDto updateQnRequestDto)
        {
            var updatedQuestion = await _questionService.UpdateQuestionAsync(id, updateQnRequestDto);
            return (updatedQuestion == null) ? NotFound() : Ok(updatedQuestion);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteQuestionAsync(Guid id)
        {
            var deletedQuestion = await _questionService.DeleteQuestionAsync(id);
            return (deletedQuestion == null) ? NotFound() : Ok(deletedQuestion);
        }

        //question Private Methods


        //private bool ValidateAddQuestionAsync(Models.DTO.AddQ addQuestionRequest)
        //{
        //    if (addQuestionRequest == null)
        //    {
        //        ModelState.AddModelError(nameof(addQuestionRequest),
        //            $"Add Question Data is required.");
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(addQuestionRequest.Code))
        //    {
        //        ModelState.AddModelError(nameof(addQuestionRequest.Code),
        //            $"{nameof(addQuestionRequest.Code)} cannot be null or empty or white space");
        //    }
        //    if (string.IsNullOrWhiteSpace(addQuestionRequest.Name))
        //    {
        //        ModelState.AddModelError(nameof(addQuestionRequest.Code),
        //            $"{nameof(addQuestionRequest.Name)} cannot be null or empty or white space");
        //    }
        //    if ((addQuestionRequest.Area <= 0))
        //    {
        //        ModelState.AddModelError(nameof(addQuestionRequest.Area),
        //            $"{nameof(addQuestionRequest.Area)} cannot be less than or equal to zero");
        //    }


        //    if ((addQuestionRequest.Population <= 0))
        //    {
        //        ModelState.AddModelError(nameof(addQuestionRequest.Population),
        //            $"{nameof(addQuestionRequest.Population)} cannot be less than zero");
        //    }

        //    if (ModelState.ErrorCount > 0)
        //    {
        //        return false;
        //    }

        //    return true;

        //}
        //private bool ValidateUpdateQuestionAsync(Models.DTO.UpdateQuestionRequest updateQuestionRequest)
        //{
        //    if (updateQuestionRequest == null)
        //    {
        //        ModelState.AddModelError(nameof(updateQuestionRequest),
        //            $"Add Question Data is required.");
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(updateQuestionRequest.Code))
        //    {
        //        ModelState.AddModelError(nameof(updateQuestionRequest.Code),
        //            $"{nameof(updateQuestionRequest.Code)} cannot be null or empty or white space");
        //    }
        //    if (string.IsNullOrWhiteSpace(updateQuestionRequest.Name))
        //    {
        //        ModelState.AddModelError(nameof(updateQuestionRequest.Code),
        //            $"{nameof(updateQuestionRequest.Name)} cannot be null or empty or white space");
        //    }
        //    if ((updateQuestionRequest.Area <= 0))
        //    {
        //        ModelState.AddModelError(nameof(updateQuestionRequest.Area),
        //            $"{nameof(updateQuestionRequest.Area)} cannot be less than or equal to zero");
        //    }

        //    if ((updateQuestionRequest.Population <= 0))
        //    {
        //        ModelState.AddModelError(nameof(updateQuestionRequest.Population),
        //            $"{nameof(updateQuestionRequest.Population)} cannot be less than zero");
        //    }

        //    if (ModelState.ErrorCount > 0)
        //    {
        //        return false;
        //    }

        //    return true;

        //}
    }

}




//using System;
//using System.Collections.Generic;
//using System.Drawing.Drawing2D;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Questions.API.Models.Entities;
//using Questions.API.Models.DTO;
//using Questions.API.Repositories;
//using Questions.API.Services;

//namespace Questions.API.Controllers
//{
//    //[ApiController]
//    //[Route("[controller]")]

//    [Route("api/v1/[controller]")]
//    [ApiExplorerSettings(GroupName = "v1")]
//    [ApiController]
//    public class QuestionController : Controller
//    {
//        private readonly QuestionService _questionService;
//        private readonly IMapper _mapper;

//        public QuestionController(QuestionService questionService, IMapper mapper)
//        {
//            _questionService = questionService;
//            _mapper = mapper;
//        }


//        [HttpGet]
//        public async Task<IActionResult> GetAllQuestionAsync()
//        {
//            var questions = await _questionService.GetAllQuestionsAsync();

//            var questionsDTO = mapper.Map<List<Models.DTO.QnDto>>(questions);
//            return Ok(questionsDTO);
//        }

//        [HttpGet]
//        [Route("{id:guid}")]
//        [ActionName("GetQuestionAsync")]
//        public async Task<IActionResult> GetQuestionAsync(Guid id)
//        {
//            var question = await questionRepository.GetAsync(id);
//            if (question == null)
//            {
//                return NotFound();
//            }

//            var questionDTO = mapper.Map<Models.DTO.QnDto>(question);
//            return Ok(questionDTO);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddQuestionAsync(Models.DTO.AddQnRequestDto addQnRequestDto)
//        {
//            // Validate the request
//            //if (!ValidateAddQuestionAsync(addQnRequestDto))
//            //{
//            //    return BadRequest(ModelState);
//            //}
//            var questionDomain = mapper.Map<Models.Entities.Qn>(addQnRequestDto);
//            questionDomain = await questionRepository.AddAsync(questionDomain);

//            var questionDTO = mapper.Map<Models.DTO.QnDto>(questionDomain);
//            return CreatedAtAction(nameof(GetQuestionAsync), new { id = questionDTO.Id }, questionDTO);
//        }

//        [HttpDelete]
//        [Route("{id:guid}")]
//        public async Task<IActionResult> DeleteQuestionAsync(Guid id)
//        {
//            var question = await questionRepository.DeleteAsync(id);
//            if (question == null)
//            {
//                return NotFound();
//            }

//            var questionDTO = mapper.Map<Models.DTO.QnDto>(question);
//            return Ok(questionDTO);
//        }

//        [HttpPut]
//        [Route("{id:guid}")]
//        public async Task<IActionResult> UpdateQuestionAsync([FromRoute] Guid id,
//            [FromBody] Models.DTO.UpdateQnRequestDto updateQnRequestDto)
//        {
//            // Validate the incoming request
//            //if (!ValidateUpdateQuestionAsync(updateQuestionRequest))
//            //{
//            //    return BadRequest(ModelState);
//            //}

//            var question = mapper.Map<Models.Entities.Qn>(updateQnRequestDto);

//            question = await questionRepository.UpdateAsync(id, question);
//            if (question == null)
//            {
//                return NotFound();
//            }

//            var questionDTO = mapper.Map<Models.DTO.QnDto>(question);
//            return Ok(questionDTO);
//        }