using System;
using Questions.API.Models.Domain;

namespace Questions.API.Repositories
{
	public interface IWalkDifficultyRepository
	{
		Task<IEnumerable<WalkDifficulty>> GetAllAsync();
		Task<WalkDifficulty> GetAsync(Guid id);
		Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty);
		Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty);
		Task<WalkDifficulty> DeleteAsync(Guid id);
	}
}

