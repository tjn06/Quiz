using System;
using System.Text.Json;
using Questions.API.Models.DTO.PlayQuiz;

namespace Questions.API.Repositories
{
    public class TriviaRepository : ITriviaRepository
    {
        public async Task<TriviaQnResponseDto?> GetTriviaQuestion()
        {
            try
            {
                var _TriviaUrl = $"https://the-trivia-api.com/api/questions?limit=1";

                using var client = new HttpClient();

                var response = await client.GetAsync(_TriviaUrl.ToLower());

                var stream = await response.Content.ReadAsStreamAsync();

                var question = await JsonSerializer.DeserializeAsync<List<TriviaQnResponseDto>>(stream);

                if (question == null)
                {
                    return null;
                }

                var questionOnFirstIndex = question[0];
                return questionOnFirstIndex;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

