using System;
using Questions.API.Models.Domain;

namespace Questions.API.Repositories
{
	public interface IAnswerRepository
	{
		Task<IEnumerable<Ans>> GetAllAsync();
		Task<Ans?> GetAsync(Guid id);
		Task<Ans> AddAsync(Ans ans);
		Task<Ans?> UpdateAsync(Guid id, Ans ans);
		Task<Ans?> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}

