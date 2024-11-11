using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Responses;

namespace WiFiSharing.Application.Interfaces
{
    public interface IReputationRepository
    {
        Task<ReputationResponseData> AddCommentAsync(ReputationDto reputationDto);
        Task<ReputationResponseData> GetCommentByIdAsync(int reputationId);
        Task<ReputationResponseData> GetAllCommentsAsync();
        Task<ReputationResponseData> DeleteCommentAsync(int reputationId);
        Task<ReputationResponseData> UpdateCommentAsync(ReputationDto reputationDto);
    }
}
