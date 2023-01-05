using System;
using AutoMapper;

namespace Questions.API.Profiles
{
	public class QuestionsProfile: Profile
	{
		public QuestionsProfile()
		{
			CreateMap<Models.Entities.Qn, Models.DTO.QnDto>()
				.ReverseMap();
            CreateMap<Models.Entities.Qn, Models.DTO.AddQnRequestDto>()
				.ReverseMap();
            CreateMap<Models.Entities.Qn, Models.DTO.UpdateQnRequestDto>()
				.ReverseMap();
            CreateMap<Models.Entities.Qn, Models.DTO.PlayQuiz.TriviaQnResponseDto>()
				.ReverseMap();
        }
	}
}

