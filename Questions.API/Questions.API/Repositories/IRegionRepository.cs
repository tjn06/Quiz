using System;
using Questions.API.Models.Domain;

namespace Questions.API.Repositories
{
	public interface IRegionRepository
	{
		Task<IEnumerable<Region>> GetAllAsync();
		Task<Region> GetAsync(Guid id);
		Task<Region> AddAsync(Region region);
		Task<Region>DeleteAsync(Guid id);
		Task<Region> UpdateAsync(Guid id, Region region);
    }
}

//Contract

