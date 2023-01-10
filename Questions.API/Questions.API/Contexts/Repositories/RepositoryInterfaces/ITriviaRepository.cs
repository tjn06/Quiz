using Questions.API.Models.DTO.PlayQuiz;

namespace Questions.API.Repositories
{
    public interface ITriviaRepository
    {
        Task<TriviaQnResponseDto?> GetTriviaQuestion();
    }
}