using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Questions.API.Models.Domain;
using Questions.API.Models.DTO;
using Questions.API.Repositories;

namespace Questions.API.Controllers
{
    //[ApiController]
    //[Route("[controller]")]

    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IMapper mapper;

        public QuestionsController(IQuestionRepository questionRepository, IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllQuestionAsync()
        {
            var questions = await questionRepository.GetAllAsync();

            var questionsDTO = mapper.Map<List<Models.DTO.QnDto>>(questions);
            return Ok(questionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetQuestionAsync")]
        public async Task<IActionResult> GetQuestionAsync(Guid id)
        {
            var question = await questionRepository.GetAsync(id);
  
            if(question == null)
            {
                return NotFound();
            }

            var questionDTO = mapper.Map<Models.DTO.QnDto>(question);

            return Ok(questionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestionAsync(Models.DTO.AddQnRequestDto addQnRequestDto)
        {
            // Validate the request
            //if (!ValidateAddQuestionAsync(addQnRequestDto))
            //{
            //    return BadRequest(ModelState);
            //}

            // Request(DTO) to domain model

            var questionDomain = mapper.Map<Models.Domain.Qn>(addQnRequestDto);

            //var question = new Models.Domain.Qn()
            //{
            //  Language = addQnRequestDto.Language,
            //  Question = addQnRequestDto.Question,
            //  Category = addQnRequestDto.Category,
            //};


            // Pass details to Repository
            questionDomain = await questionRepository.AddAsync(questionDomain);

            // Convert back to DTO
            var questionDTO = mapper.Map<Models.DTO.QnDto>(questionDomain);
            //var questionDTO = new Models.DTO.QnDto
            //{
            //    Id = question.Id,
            //    Language = addQnRequestDto.Language,
            //    Question = addQnRequestDto.Question,
            //    Category = addQnRequestDto.Category,
            //};

            return CreatedAtAction(nameof(GetQuestionAsync), new {id = questionDTO.Id}, questionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteQuestionAsync(Guid id)
        {
            // Get question from database
            var question = await questionRepository.DeleteAsync(id);

            // If null NotFond
            if (question == null)
            {
                return NotFound();
            }

            // Convert response back to DTO
            var questionDTO = mapper.Map<Models.DTO.QnDto>(question);
            //var questionDTO = new Models.DTO.QnDto
            //{
            //    Id = question.Id,
            //    Language = question.Language,
            //    Question = question.Question,
            //    Category = question.Category,
            //};

            // Return Ok response
            return Ok(questionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateQuestionAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateQnRequestDto updateQnRequestDto)
        {
            // Validate the incoming request
            //if (!ValidateUpdateQuestionAsync(updateQuestionRequest))
            //{
            //    return BadRequest(ModelState);
            //}
            // Convert DTO to Domain model

            var question = mapper.Map<Models.Domain.Qn>(updateQnRequestDto);
            //var question = new Models.Domain.Qn()
            //{
            //    Language = updateQnRequestDto.Language,
            //    Question = updateQnRequestDto.Question,
            //    Category = updateQnRequestDto.Category,
            //};

            // Update Question using repository
            //await questionRepository.UpdateAsync(id, question);
            question = await questionRepository.UpdateAsync(id, question);


            // If Null then not found
            if(question == null)
            {
                return NotFound();
            }

            // Convert Domain back to DTO

            var questionDTO = mapper.Map<Models.DTO.QnDto>(question);
            //var questionDTO = new Models.DTO.QnDto
            //{
            //    Id = question.Id,
            //    Language = question.Language,
            //    Question = question.Question,
            //    Category = question.Category,
            //};

            // Return Ok response
            return Ok(questionDTO);
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