using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Questions.API.Models.DTO;
using Questions.API.Repositories;

namespace Questions.API.Controllers
{
    //[ApiController]
    //[Route("[controller]")]

    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]

    public class AnswerController : Controller
    {
        private readonly IAnswerRepository answerRepository;
        private readonly IMapper mapper;

        public AnswerController(IAnswerRepository answersRepository, IMapper mapper)
        {
            this.answerRepository = answersRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnswersAsync()
        {
            var answerDomain = await answerRepository.GetAllAsync();

            var answerDTO = mapper.Map<List<Models.DTO.AnsDto>>(answerDomain);
            return Ok(answerDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetAnswerAsync")]
        public async Task<IActionResult> GetAnswerAsync(Guid id)
        {
            var answerDomain = await answerRepository.GetAsync(id);

            var answerDTO = mapper.Map<Models.DTO.AnsDto>(answerDomain);
            return Ok(answerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswerAsync([FromBody] Models.DTO.AddAnsRequestDto addAnswerRequestDto)
        {
            var answerDomain = mapper.Map<Models.Domain.Ans>(addAnswerRequestDto);
            answerDomain = await answerRepository.AddAsync(answerDomain);

            var answerDTO = mapper.Map<Models.DTO.AnsDto>(answerDomain);
            return CreatedAtAction(nameof(GetAnswerAsync), new { id = answerDTO.Id }, answerDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAnswerAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateAnsRequestDto updateAnsRequestDto)
        {
            var answerDomain = mapper.Map<Models.Domain.Ans>(updateAnsRequestDto);
            answerDomain = await answerRepository.UpdateAsync(id, answerDomain);

            if (answerDomain == null)
            {
                return NotFound();
            }

            var answerDTO = mapper.Map<Models.DTO.AnsDto>(answerDomain);
            return Ok(answerDTO);
          
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
            var answerDomain = await answerRepository.DeleteAsync(id);
            if(answerDomain == null)
            {
                return NotFound();
            }

            var answerDTO = mapper.Map<Models.DTO.AnsDto>(answerDomain);
            return Ok(answerDTO);

        }

      
    }
}