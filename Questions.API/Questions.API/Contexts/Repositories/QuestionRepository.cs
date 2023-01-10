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
            try { 
                question.Id = Guid.NewGuid();
                await _quizDBContext.AddAsync(question);
                await _quizDBContext.SaveChangesAsync();

                return question;

            } catch (Exception ex)
            {
                throw new Exception($"{nameof(question)} could not be saved: {ex.Message}");
            }
        }

        public async Task<Qn> AddTriviaQuestionAsync(Qn question)
        {
            try
            {
                await _quizDBContext.AddAsync(question);
                await _quizDBContext.SaveChangesAsync();

                return question;

            } catch (Exception ex)
            {
                throw new Exception($"{nameof(question)} could not be saved: {ex.Message}");
            }
        }

        public async Task<Qn?> DeleteAsync(Guid id)
        {
            var question = await _quizDBContext.Qns.FirstOrDefaultAsync(x => x.Id == id);

            if( question == null)
            {
                return null;
            }

            try
            {
                _quizDBContext.Qns.Remove(question);
                await _quizDBContext.SaveChangesAsync();

                return question;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(id)} could not be deleted: {ex.Message}");
            }

        }

        public async Task<IEnumerable<Qn>> GetAllAsync()
        {
            try
            {
                return await _quizDBContext.Qns.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve questions: {ex.Message}");  
            }
        }

        public async Task<Qn?> GetAsync(Guid id)
        {
            try {

                return await _quizDBContext.Qns.FirstOrDefaultAsync(x => x.Id == id);

            } catch (Exception ex)
            {
                throw new Exception($"{nameof(id)} could not be retrived: {ex.Message}");
            }
        }

        public async Task<Qn?> UpdateAsync(Guid id, Qn question)
        {
            var existingQuestion = await _quizDBContext.Qns.FirstOrDefaultAsync(x => x.Id == id);

            if (existingQuestion == null)
            {
                return null;
            }

            try
            {
                existingQuestion.Language = question.Language;
                existingQuestion.Question = question.Question;
                existingQuestion.Category = question.Category;

                await _quizDBContext.SaveChangesAsync();
                return existingQuestion;

            } catch (Exception ex)
            {
                throw new Exception($"{nameof(id)} could not be updated: {ex.Message}");
            }

        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var question = await GetAsync(id);
            return question != null;
        }
    }
}

