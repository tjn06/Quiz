using System;
using AutoMapper;
using Questions.API.Models.DTO;
using Questions.API.Repositories;

namespace Questions.API.Services
{
	public class QuestionService : IQuestionService
	{
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
		{
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<List<QnDto>?> GetAllQuestionsAsync()
        {
            var questionsDomain = await _questionRepository.GetAllAsync();
            return (questionsDomain == null ) ? null : _mapper.Map<List<Models.DTO.QnDto>>(questionsDomain);
        }

        public async Task<QnDto?> GetQuestionAsync(Guid id)
        {
            var questionDomain = await _questionRepository.GetAsync(id);
            return (questionDomain == null) ? null : _mapper.Map<QnDto>(questionDomain);
        }

        public async Task<QnDto?> AddQuestionAsync(Models.DTO.AddQnRequestDto addQuestionRequestDto)
        {
            var questionDomain = _mapper.Map<Models.Entities.Qn>(addQuestionRequestDto);
            questionDomain = await _questionRepository.AddAsync(questionDomain);
            return (questionDomain == null) ? null: _mapper.Map<Models.DTO.QnDto>(questionDomain);
        }

        public async Task<QnDto?> UpdateQuestionAsync(Guid id, UpdateQnRequestDto updateQnRequestDto)
        {
            var questionDomain = _mapper.Map<Models.Entities.Qn>(updateQnRequestDto);
            questionDomain = await _questionRepository.UpdateAsync(id, questionDomain);
            return (questionDomain == null) ? null : _mapper.Map<Models.DTO.QnDto>(questionDomain);
        }

        public async Task<QnDto?> DeleteQuestionAsync(Guid id)
        {
            var questionDomain = await _questionRepository.DeleteAsync(id);
            return (questionDomain == null) ? null : _mapper.Map<Models.DTO.QnDto>(questionDomain);
        }
    }
}

