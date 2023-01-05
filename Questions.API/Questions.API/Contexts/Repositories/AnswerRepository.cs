using System;
using Microsoft.EntityFrameworkCore;
using Questions.API.Percistanse;
using Questions.API.Models.Entities;

namespace Questions.API.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizDBContext _quizDBContext;

        public AnswerRepository(QuizDBContext quizDBContext)
        {
            _quizDBContext = quizDBContext;
        }

        public async Task<Ans> AddAsync(Ans answer)
        {
            answer.Id = Guid.NewGuid();
            await _quizDBContext.Answers.AddAsync(answer);
            await _quizDBContext.SaveChangesAsync();
            return answer;
        }

        public async Task<Ans?> DeleteAsync(Guid id)
        {
            var existingAnswer = await _quizDBContext.Answers.FindAsync(id);

            if( existingAnswer == null)
            {
                return null;
            }

            _quizDBContext.Answers.Remove(existingAnswer);
            await _quizDBContext.SaveChangesAsync();
            return existingAnswer;
        }

        public async Task<IEnumerable<Ans>> GetAllAsync()
        {
            return await _quizDBContext.Answers.ToListAsync();
        }

        public Task<Ans?> GetAsync(Guid id)
        {
            return _quizDBContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ans?> UpdateAsync(Guid id, Ans answer)
        {
            var existingAnswer = await _quizDBContext.Answers.FindAsync(id);

            if(existingAnswer != null)
            {
                existingAnswer.QuestionId = answer.QuestionId;
                existingAnswer.Answer = answer.Answer;
                existingAnswer.IsCorrectAnswer = answer.IsCorrectAnswer;

                // Important if non-appearance, walk not saved to database
                await _quizDBContext.SaveChangesAsync();
                return existingAnswer;
            }
            return null;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var answer = await GetAsync(id);
            return answer != null;
        }

    }
}

