using System;
using Microsoft.EntityFrameworkCore;
using Questions.API.Data;
using Questions.API.Models.Domain;

namespace Questions.API.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizDBContext quizDBContext;

        public AnswerRepository(QuizDBContext quizDBContext)
        {
            this.quizDBContext = quizDBContext;
        }

        public async Task<Ans> AddAsync(Ans ans)
        {
            // Assign new ID
            ans.Id = Guid.NewGuid();
            await quizDBContext.Answers.AddAsync(ans);
            await quizDBContext.SaveChangesAsync();
            return ans;
        }

        public async Task<Ans?> DeleteAsync(Guid id)
        {
            var existingAnswer = await quizDBContext.Answers.FindAsync(id);

            if( existingAnswer == null)
            {
                return null;
            }

            quizDBContext.Answers.Remove(existingAnswer);
            await quizDBContext.SaveChangesAsync();
            return existingAnswer;
        }

        public async Task<IEnumerable<Ans>> GetAllAsync()
        {
            return await quizDBContext.Answers.ToListAsync();
        }

        public Task<Ans?> GetAsync(Guid id)
        {
            return quizDBContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ans?> UpdateAsync(Guid id, Ans ans)
        {
            var existingAnswer = await quizDBContext.Answers.FindAsync(id);

            if(existingAnswer != null)
            {
                existingAnswer.QuestionId = ans.QuestionId;
                existingAnswer.Answer = ans.Answer;
                existingAnswer.IsCorrectAnswer = ans.IsCorrectAnswer;

                // Important if non-appearance, walk not saved to database
                await quizDBContext.SaveChangesAsync();
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

