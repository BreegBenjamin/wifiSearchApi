using WiFiSharing.Application.Responses;

namespace WiFiSharing.Application.Interfaces
{
    public interface IAdminRepository
    {
        Task<AdminResponseData> GetAllAdminsAsync();
        Task<AdminResponseData> GetAdminByUserIdAsync(int userId);
        Task<AdminResponseData> AddAdminAsync(int userId, string adminLevel);
        Task<AdminResponseData> UpdateAdminAsync(int userId, string adminLevel);
        Task<AdminResponseData> DeleteAdminAsync(int userId);
    }
}
