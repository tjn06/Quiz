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


        // Add region
        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;

        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();
            // Return region if client want to do something with it
            return region;
        }


        //Method to provide all regions from database
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
           return await nZWalksDbContext.Regions.ToListAsync();
        }


        public async Task<Region> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await nZWalksDbContext.SaveChangesAsync();
            return existingRegion;

        }
    }
}

