using System;
using Questions.API.Models.DTO;

namespace Questions.API.Services
{
    public interface IQuestionService
    {
        Task<QnDto?> AddQuestionAsync(AddQnRequestDto addQuestionRequestDto);
        Task<QnDto?> DeleteQuestionAsync(Guid id);
        Task<List<QnDto>?> GetAllQuestionsAsync();
        Task<QnDto?> GetQuestionAsync(Guid id);
        Task<QnDto?> UpdateQuestionAsync(Guid id, UpdateQnRequestDto updateQnRequestDto);
    }
}

