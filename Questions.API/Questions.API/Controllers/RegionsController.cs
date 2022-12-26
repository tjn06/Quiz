using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Questions.API.Models.Domain;
using Questions.API.Repositories;

namespace Questions.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // Data from the database
            var regions = await regionRepository.GetAllAsync();

            //Return DTO regions
            //var regionsDTO = new List<Models.DTO.Region>();

            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population
            //    };

            //    regionsDTO.Add(regionDTO);
            //});


            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            // Expose the DTO to the client, not the domain
            return Ok(regionsDTO);
        }




    }
}


//[HttpGet]
//public IActionResult GetAllRegions()
//{
//    var regions = new List<Region>()
//            {
//                new Region
//                {
//                    Id = Guid.NewGuid(),
//                    Name = "Wellington",
//                    Code = "WLG",
//                    Area = 22222,
//                    Lat = 1.17,
//                    Long = 299.44,
//                    Population = 50000
//                },

//            };

//    return Ok(regions);
//}