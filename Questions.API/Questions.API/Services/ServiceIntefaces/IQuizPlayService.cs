using Questions.API.Models.DTO;
using Questions.API.Models.DTO.PlayQuiz;
using Questions.API.Models.Entities;

namespace Questions.API.Services
{
    public interface IQuizPlayService
    {
        Task<Qn?> AddAndGetTriviaQuestion();
        Task<bool> CheckIfQuestionExistsInDb(Guid id);
        PlayQuizQuestion CreatePlayQuizQuestion(Qn question, List<AnsPlayQuizDto> answers);
        Task<string> GetPlayQuizAnswerCorrectionReply(Guid questionId, Guid answerId);
        Task<PlayQuizQuestion?> GetPlayQuizQuestion();
        Task<Qn> GetRandomQuestionFromDb();
        Task<List<AnsPlayQuizDto>> GetShuffledQuestionAnswersFromDB(Qn question);
        bool RandomBoolean();
        void SaveCorrectTriviaAnswers(TriviaQnResponseDto qn, Guid questionId);
        void SaveIncorrectTriviaAnswers(TriviaQnResponseDto questionFromTriva, Qn triviaQuestionEntity);
        void SaveTriviaQuestion(Qn qn);
    }
}