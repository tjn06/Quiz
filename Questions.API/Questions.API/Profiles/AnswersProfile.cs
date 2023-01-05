using System;
using System.Collections.Generic;
using AutoMapper;
using Questions.API.Models.DTO;

namespace Questions.API.Profiles
{
	public class AnswersProfile : Profile
	{
		public AnswersProfile()
		{
			CreateMap<Models.Entities.Ans, Models.DTO.AnsDto>()
				.ReverseMap();

            CreateMap<Models.Entities.Ans, Models.DTO.AddAnsRequestDto>()
				.ReverseMap();

            CreateMap<Models.Entities.Ans, Models.DTO.UpdateAnsRequestDto>()
                .ReverseMap();

            CreateMap<Models.Entities.Ans, Models.DTO.AnsPlayQuizDto>()
				.ReverseMap();
        }
	}
}