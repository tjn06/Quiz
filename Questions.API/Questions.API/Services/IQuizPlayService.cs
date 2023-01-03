﻿using Questions.API.Models.Domain;
using Questions.API.Models.DTO;
using Questions.API.Models.DTO.PlayQuiz;

namespace Questions.API.Services
{
    public interface IQuizPlayService
    {
        Task<Qn> AddAndGetTriviaQuestion();
        Task<bool> CheckIfQuestionExistsInDb(Guid id);
        PlayQuizQuestion CreatePlayQuizQuestion(Qn question, List<AnsPlayQuizDto> answers);
        Task<string> GetPlayQuizAnswerCorrectionReply(Guid questionId, Guid answerId);
        Task<PlayQuizQuestion> GetPlayQuizQuestion();
        Task<Qn> GetRandomQuestionFromDb();
        void SaveCorrectTriviaAnswers(TriviaQnResponseDto qn, Guid questionId);
        void SaveIncorrectTriviaAnswers(string answerStr, Guid questionId);
        void SaveTriviaQuestion(Qn qn);
    }
}