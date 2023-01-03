using System;
using AutoMapper;
using NuGet.Protocol.Core.Types;
using Microsoft.EntityFrameworkCore;
using Questions.API.Models.Domain;
using Questions.API.Repositories;
using Microsoft.AspNetCore.Hosting.Server;
using Elfie.Serialization;
using System.Collections.Generic;
using Questions.API.Models.DTO.PlayQuiz;
using Questions.API.Models.DTO;
using System.Linq;
//using Questions.API.Repositories.RepositoryInterfaces;



namespace Questions.API.Services
{
    public class QuizPlayService : IQuizPlayService
    {
        private readonly IAnswerRepository answerRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly ITriviaRepository triviaRepository;
        private readonly IMapper mapper;


        public QuizPlayService(IAnswerRepository answerRepository,
            IQuestionRepository questionRepository, ITriviaRepository triviaRepositroy, IMapper mapper)
        {
            this.answerRepository = answerRepository;
            this.questionRepository = questionRepository;
            this.triviaRepository = triviaRepositroy;
            this.mapper = mapper;
        }

        // Expose question

        public async Task<string> GetPlayQuizAnswerCorrectionReply(Guid questionId, Guid answerId)
        {
            var answer = await answerRepository.GetAsync(answerId);
            var question = await questionRepository.GetAsync(questionId);

            if (answer == null)
            {
                return $"AnswerID: {answerId} does not exist";
            }
            if (question == null)
            {
                return $"QuestionID: {questionId} does not exist";
            }
            // Check if answer is related to the question
            if (answer.QuestionId == question.Id)
            {
                if (answer.IsCorrectAnswer)
                {
                    return $"{answer.Answer} is correct";
                }
                else
                {
                    return $"{answer.Answer} is incorrect";
                }
            }
            else
            {
                return $"{answer.Answer} is incorrect and not an answer-option related to the question";
            }
        }


        public async Task<PlayQuizQuestion> GetPlayQuizQuestion()
        {
            Random rnd = new Random();
            bool triviaOrDb = Convert.ToBoolean(rnd.Next(0, 2));
            var question = new Qn { };

            if (triviaOrDb)
            {
                question = await GetRandomQuestionFromDb();
            }
            else
            {
                question = await AddAndGetTriviaQuestion();
            }

            var allAnswersFromDb = await answerRepository.GetAllAsync();

            // Get answers related to question
            var questionAnswers = from answersFromDb in allAnswersFromDb
                                  where question.Id == answersFromDb.QuestionId
                                  select answersFromDb;

            // Dto-mapping, exclude AnswerIsCorrect in answersToClient
            var answersToClient = mapper.Map<List<Models.DTO.AnsPlayQuizDto>>(questionAnswers);

            // Shuffle answers
            Random rng = new Random();
            var shuffledClientAnswers = answersToClient.OrderBy(a => rng.Next()).ToList();

            var playQuizQuestion = CreatePlayQuizQuestion(question, shuffledClientAnswers);

            return playQuizQuestion;
        }


        public async Task<Qn> GetRandomQuestionFromDb()
        {
  
            Random rng = new Random();

            var allPlayQuizQuestions = await questionRepository.GetAllAsync();

            var playQuizQuestion = allPlayQuizQuestions.ElementAt(rng.Next(0, allPlayQuizQuestions.Count()));

            return playQuizQuestion;

            //var allPlayQuizQuestions = await questionRepository.GetAllAsync();
            //var playQuizQuestion = allPlayQuizQuestions.ElementAt(0);

            //return playQuizQuestion;
        }


        public async Task<Qn> AddAndGetTriviaQuestion()
        {
            var questionFromTriva = await triviaRepository.GetTriviaQuestion();
            var constructedGuid = CreateGuidFromTriviaString(questionFromTriva.id);

            var triviaQuestionDto = new Models.Domain.Qn()
            {
                Id = constructedGuid,
                Language = "English",
                Question = questionFromTriva.question,
                Category = questionFromTriva.category,
            };

            if (await CheckIfQuestionExistsInDb(triviaQuestionDto.Id) == false)
            {
                SaveTriviaQuestion(triviaQuestionDto);

                SaveCorrectTriviaAnswers(questionFromTriva, triviaQuestionDto.Id);

                questionFromTriva.incorrectAnswers.ForEach(answer => SaveIncorrectTriviaAnswers(answer, triviaQuestionDto.Id));
            }

                // Get newly added triviaQuestion from db to verify existense in db
                return await questionRepository.GetAsync(triviaQuestionDto.Id);
        }


        public static Guid CreateGuidFromTriviaString(string triviaId)
        {
            string constructedGuidString = triviaId.Insert(0, "00000000");
            constructedGuidString = constructedGuidString.Insert(8, "-");
            constructedGuidString = constructedGuidString.Insert(13, "-");
            constructedGuidString = constructedGuidString.Insert(18, "-");
            constructedGuidString = constructedGuidString.Insert(23, "-");
            if (Guid.TryParse(constructedGuidString, out var newGuid))
            {
                Console.WriteLine($"TriviaId to Guid conversion succeded");
                return newGuid;
            }
            else
            {
                Console.WriteLine($"TriviaId {constructedGuidString} to Guid conversion failed. A random Guid is created instead");
                return Guid.NewGuid();
            }
        }

        public async Task<bool> CheckIfQuestionExistsInDb(Guid id)
        {
            return await questionRepository.ExistsAsync(id);
        }

        public async void SaveTriviaQuestion(Qn qn)
        {
            await questionRepository.AddTriviaQuestionAsync(qn);
        }


        public async void SaveCorrectTriviaAnswers(TriviaQnResponseDto qn, Guid questionId)
        {
            Ans answer = new Ans();
            answer.Answer = qn.correctAnswer;
            answer.IsCorrectAnswer = true;
            answer.QuestionId = questionId;
            await answerRepository.AddAsync(answer);
        }

        public async void SaveIncorrectTriviaAnswers(string answerStr, Guid questionId)
        {
            Ans answer = new Ans();
            answer.Answer = answerStr;
            answer.IsCorrectAnswer = false;
            answer.QuestionId = questionId;
            await answerRepository.AddAsync(answer);
        }

        public PlayQuizQuestion CreatePlayQuizQuestion(Qn question, List<Models.DTO.AnsPlayQuizDto> answers)
        {
            PlayQuizQuestion playQuizQuestion = new PlayQuizQuestion();
            playQuizQuestion.Id = question.Id;
            playQuizQuestion.Question = question.Question;
            playQuizQuestion.Category = question.Category;

            answers.ForEach(answer => playQuizQuestion.Answers.Add(answer));

            return playQuizQuestion;
        }


    }
}

