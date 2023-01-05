using System;
using Questions.API.Models.Entities;

namespace Questions.API.Repositories
{
	public interface IQuestionRepository
	{
		Task<IEnumerable<Qn>> GetAllAsync();
		Task<Qn?> GetAsync(Guid id);
		Task<Qn?> AddAsync(Qn question);
		Task<Qn> AddTriviaQuestionAsync(Qn question);
        Task<Qn?>DeleteAsync(Guid question);
		Task<Qn?> UpdateAsync(Guid id, Qn question);
		Task<bool> ExistsAsync(Guid id);
    }
}

//Contract

