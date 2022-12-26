using System;
using Questions.API.Models.Domain;

namespace Questions.API.Repositories
{
	public interface IRegionRepository
	{
		Task<IEnumerable<Region>> GetAllAsync();
	}
}

//Contract

