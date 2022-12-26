using System;
using Microsoft.EntityFrameworkCore;
using Questions.API.Data;
using Questions.API.Models.Domain;

namespace Questions.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        // Use this private property inside method
        private readonly NZWalksDBContext nZWalksDbContext;


        // Constructor, injecting DBcontext in the constuctor
        public RegionRepository(NZWalksDBContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        //Method to provide all regions from database
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
           return await nZWalksDbContext.Regions.ToListAsync();
        }
    }
}

