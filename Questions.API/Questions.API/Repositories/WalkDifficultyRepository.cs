using System;
using Microsoft.EntityFrameworkCore;
using Questions.API.Data;
using Questions.API.Models.Domain;

namespace Questions.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDBContext nZWalksDBContext;

        public WalkDifficultyRepository(NZWalksDBContext nZWalksDBContext)
        {
            this.nZWalksDBContext = nZWalksDBContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = new Guid();
            await nZWalksDBContext.WalkDifficulty.AddAsync(walkDifficulty);
            await nZWalksDBContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await nZWalksDBContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await nZWalksDBContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
           var existiongWalkDifficulty = await nZWalksDBContext.WalkDifficulty.FindAsync(id);
            if(existiongWalkDifficulty == null)
            {
                return null;
            }

            existiongWalkDifficulty.Code = walkDifficulty.Code;
            await nZWalksDBContext.SaveChangesAsync();
            return existiongWalkDifficulty;
        }
    }
}

