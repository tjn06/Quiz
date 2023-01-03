using System;
using AutoMapper;

namespace Questions.API.Profiles
{
	public class QuestionProfile: Profile
	{
		public QuestionProfile()
		{
			CreateMap<Models.Domain.Qn, Models.DTO.QnDto>()
				.ReverseMap();
            CreateMap<Models.Domain.Qn, Models.DTO.AddQnRequestDto>()
				.ReverseMap();
            CreateMap<Models.Domain.Qn, Models.DTO.UpdateQnRequestDto>()
				.ReverseMap();
            //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id));
            CreateMap<Models.Domain.Qn, Models.DTO.PlayQuiz.TriviaQnResponseDto>()
				.ReverseMap();

        }
	}
}

