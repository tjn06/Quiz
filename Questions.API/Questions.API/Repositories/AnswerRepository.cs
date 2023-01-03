using System;
using Microsoft.EntityFrameworkCore;
using Questions.API.Data;
using Questions.API.Models.Domain;

namespace Questions.API.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly NZWalksDBContext nZWalksDbContext;

        public AnswerRepository(NZWalksDBContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Ans> AddAsync(Ans ans)
        {
            // Assign new ID
            ans.Id = Guid.NewGuid();
            await nZWalksDbContext.Answers.AddAsync(ans);
            await nZWalksDbContext.SaveChangesAsync();
            return ans;
        }

        public async Task<Ans?> DeleteAsync(Guid id)
        {
            var existingAnswer = await nZWalksDbContext.Answers.FindAsync(id);

            if( existingAnswer == null)
            {
                return null;
            }

            nZWalksDbContext.Answers.Remove(existingAnswer);
            await nZWalksDbContext.SaveChangesAsync();
            return existingAnswer;
        }

        public async Task<IEnumerable<Ans>> GetAllAsync()
        {
            return await nZWalksDbContext.Answers.ToListAsync();
        }

        public Task<Ans?> GetAsync(Guid id)
        {
            return nZWalksDbContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ans?> UpdateAsync(Guid id, Ans ans)
        {
            var existingAnswer = await nZWalksDbContext.Answers.FindAsync(id);

            if(existingAnswer != null)
            {
                existingAnswer.QuestionId = ans.QuestionId;
                existingAnswer.Answer = ans.Answer;
                existingAnswer.IsCorrectAnswer = ans.IsCorrectAnswer;

                // Important if non-appearance, walk not saved to database
                await nZWalksDbContext.SaveChangesAsync();
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

