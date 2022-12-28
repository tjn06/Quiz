using System;
using Microsoft.EntityFrameworkCore;
using Questions.API.Models.Domain;

namespace Questions.API.Data
{

   
    public class NZWalksDBContext : DbContext
	{
        readonly Guid region1Id = Guid.NewGuid();
        readonly Guid region2Id = Guid.NewGuid();
        readonly Guid walk1Id = Guid.NewGuid();
        readonly Guid walk2Id = Guid.NewGuid();
        readonly Guid diffiCultWalk1Id = Guid.NewGuid();
        readonly Guid diffiCultWalk2Id = Guid.NewGuid();

        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> options): base(options)
		{
            
        }
		public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            CreateRegionsModel(modelBuilder);
            CreateWalksModel(modelBuilder);
            CreateWalkDifficulltyModel(modelBuilder);
        }


        private void CreateRegionsModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasData(
                    new Region
                    {
                        Id = region1Id,
                        Code = "AUCK",
                        Name = "Auckland",
                        Area = 22,
                        Lat = 33,
                        Long = 44,
                        Population = 45,
                    },
                    new Region
                    {
                        Id = region2Id,
                        Code = "NEW",
                        Name = "Newland",
                        Area = 34,
                        Lat = 22,
                        Long = 11,
                        Population = 77,
                    }
                );
            });
        }


        private void CreateWalksModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Walk>(entity =>
            {
                entity.HasData(
                    new Walk
                    {
                        Id = walk1Id,
                        Name = "One Three Hill Walk",
                        Length = 3.5,
                        RegionId = region1Id,
                        WalkDifficultyId = diffiCultWalk1Id,
                        //Region = null,
                        //WalkDifficulty = null
                    },
                    new Walk
                    {
                        Id = walk2Id,
                        Name = "Rainbow Mou",
                        Length = 3.5,
                        RegionId = region2Id,
                        WalkDifficultyId = diffiCultWalk2Id,
                        //Region = null,
                        //WalkDifficulty = null
                    }
                );
            });
        }

        private void CreateWalkDifficulltyModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WalkDifficulty>(entity =>
            {
                entity.HasData(
                    new WalkDifficulty
                    {
                        Id = diffiCultWalk1Id,
                        Code = "Code 1"
          
                    },
                    new WalkDifficulty
                    {
                        Id = diffiCultWalk2Id,
                        Code = "Code 2"

                    }
                );
            });
        }

    }
}

