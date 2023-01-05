using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Questions.API.Models.DTO;
using Questions.API.Repositories;

namespace Questions.API.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<List<AnsDto>?> GetAllAnswersAsync()
        {
            var answerDomain = await _answerRepository.GetAllAsync();
            return (answerDomain == null) ? null : _mapper.Map<List<Models.DTO.AnsDto>>(answerDomain);
        }

        public async Task<Models.DTO.AnsDto?> GetAnswerAsync(Guid id)
        {
            var answerDomain = await _answerRepository.GetAsync(id);
            return (answerDomain == null) ? null : _mapper.Map<Models.DTO.AnsDto>(answerDomain);
        }

        public async Task<AnsDto?> AddAnswerAsync(Models.DTO.AddAnsRequestDto addAnswerRequestDto)
        {
            var answerDomain = _mapper.Map<Models.Entities.Ans>(addAnswerRequestDto);
            answerDomain.Id = Guid.NewGuid();
            answerDomain = await _answerRepository.AddAsync(answerDomain);
            return (answerDomain == null) ? null : _mapper.Map<Models.DTO.AnsDto>(answerDomain);
        }

        public async Task<AnsDto?> UpdateAnswerAsync(Guid id, Models.DTO.UpdateAnsRequestDto updateAnsRequestDto)
        {
            var answerDomain = _mapper.Map<Models.Entities.Ans>(updateAnsRequestDto);
            answerDomain = await _answerRepository.UpdateAsync(id, answerDomain);
            return (answerDomain == null) ? null : _mapper.Map<Models.DTO.AnsDto>(answerDomain);
        }

        public async Task<AnsDto?> DeleteAnswerAsync(Guid id)
        {
            var answerDomain = await _answerRepository.DeleteAsync(id);
            return (answerDomain == null) ? null : _mapper.Map<Models.DTO.AnsDto>(answerDomain);
        }

    }
}