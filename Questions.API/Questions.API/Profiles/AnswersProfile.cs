﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Questions.API.Models.DTO;

namespace Questions.API.Profiles
{
	public class AnswersProfile : Profile
	{
		public AnswersProfile()
		{
			CreateMap<Models.Domain.Ans, Models.DTO.AnsDto>()
				.ReverseMap();

            CreateMap<Models.Domain.Ans, Models.DTO.AddAnsRequestDto>()
				.ReverseMap();

            CreateMap<Models.Domain.Ans, Models.DTO.UpdateAnsRequestDto>()
                .ReverseMap();

            CreateMap<Models.Domain.Ans, Models.DTO.AnsPlayQuizDto>()
				.ReverseMap();
        }
	}
}

//         CreateMap<IEnumerable<Models.Domain.Ans>, List<Models.DTO.AnsPlayQuizDto>>()
//.ReverseMap();

//CreateMap<Models.Domain.Ans, Models.DTO.AnsDto>();