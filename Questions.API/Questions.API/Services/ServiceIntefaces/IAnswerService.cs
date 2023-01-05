using Questions.API.Models.DTO;

namespace Questions.API.Services
{
    public interface IAnswerService
    {
        Task<AnsDto?> AddAnswerAsync(AddAnsRequestDto addAnswerRequestDto);
        Task<AnsDto?> DeleteAnswerAsync(Guid id);
        Task<List<AnsDto>?> GetAllAnswersAsync();
        Task<AnsDto?> GetAnswerAsync(Guid id);
        Task<AnsDto?> UpdateAnswerAsync(Guid id, UpdateAnsRequestDto updateAnsRequestDto);
    }
}