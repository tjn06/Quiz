using Questions.API.Models.Entities;

namespace Questions.API.Services
{
    public interface IQuizPlayService
    {
        Task<string> GetPlayQuizAnswerCorrectionReply(Guid questionId, Guid answerId);
        Task<PlayQuizQuestion?> GetPlayQuizQuestion();
    }
}