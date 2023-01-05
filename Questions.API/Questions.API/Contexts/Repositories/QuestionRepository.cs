using System;
using Microsoft.EntityFrameworkCore;
using Questions.API.Percistanse;
using Questions.API.Models.Entities;

namespace Questions.API.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizDBContext _quizDBContext;

        public QuestionRepository(QuizDBContext quizDBContext)
        {
            _quizDBContext = quizDBContext;
        }

        public async Task<Qn?> AddAsync(Qn question)
        {
            question.Id = Guid.NewGuid();
            await _quizDBContext.AddAsync(question);
            await _quizDBContext.SaveChangesAsync();
            return question;
        }

        public async Task<Qn> AddTriviaQuestionAsync(Qn question)
        {
            await _quizDBContext.AddAsync(question);
            await _quizDBContext.SaveChangesAsync();
            return question;
        }

        public async Task<Qn?> DeleteAsync(Guid id)
        {
            var question = await _quizDBContext.Qns.FirstOrDefaultAsync(x => x.Id == id);

            if(question == null)
            {
                return null;
            }
            _quizDBContext.Qns.Remove(question);
            await _quizDBContext.SaveChangesAsync();
            return question;
        }


        public async Task<IEnumerable<Qn>> GetAllAsync()
        {
           return await _quizDBContext.Qns.ToListAsync();
        }


        public async Task<Qn?> GetAsync(Guid id)
        {
            return await _quizDBContext.Qns.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Qn?> UpdateAsync(Guid id, Qn question)
        {
            var existingQuestion = await _quizDBContext.Qns.FirstOrDefaultAsync(x => x.Id == id);

            if (existingQuestion == null)
            {
                return null;
            }
            existingQuestion.Language = question.Language;
            existingQuestion.Question = question.Question;
            existingQuestion.Category = question.Category;

            await _quizDBContext.SaveChangesAsync();
            return existingQuestion;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var question = await GetAsync(id);
            return question != null;
        }
    }
}

