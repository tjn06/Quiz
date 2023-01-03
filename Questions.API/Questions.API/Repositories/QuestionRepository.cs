using System;
using Microsoft.EntityFrameworkCore;
using Questions.API.Data;
using Questions.API.Models.Domain;

namespace Questions.API.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        // Use this private property inside method
        private readonly NZWalksDBContext nZWalksDbContext;


        // Constructor, injecting DBcontext in the constuctor
        public QuestionRepository(NZWalksDBContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }


        // Add region
        public async Task<Qn> AddAsync(Qn question)
        {
            question.Id = Guid.NewGuid();
            await nZWalksDbContext.AddAsync(question);
            await nZWalksDbContext.SaveChangesAsync();
            return question;
        }

        public async Task<Qn> AddTriviaQuestionAsync(Qn question)
        {
            await nZWalksDbContext.AddAsync(question);
            await nZWalksDbContext.SaveChangesAsync();
            return question;
        }

        public async Task<Qn?> DeleteAsync(Guid id)
        {
            var question = await nZWalksDbContext.Qns.FirstOrDefaultAsync(x => x.Id == id);

            if(question == null)
            {
                return null;
            }

            nZWalksDbContext.Qns.Remove(question);
            await nZWalksDbContext.SaveChangesAsync();
            // Return region if client want to do something with it
            return question;
        }


        //Method to provide all questions from database
        public async Task<IEnumerable<Qn>> GetAllAsync()
        {
           return await nZWalksDbContext.Qns.ToListAsync();
        }


        public async Task<Qn> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Qns.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Qn?> UpdateAsync(Guid id, Qn qn)
        {
            var existingQuestion = await nZWalksDbContext.Qns.FirstOrDefaultAsync(x => x.Id == id);

            if (existingQuestion == null)
            {
                return null;
            }
            existingQuestion.Language = qn.Language;
            existingQuestion.Question = qn.Question;
            existingQuestion.Category = qn.Category;

            await nZWalksDbContext.SaveChangesAsync();
            return existingQuestion;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var question = await GetAsync(id);
            return question != null;
        }
    }
}

