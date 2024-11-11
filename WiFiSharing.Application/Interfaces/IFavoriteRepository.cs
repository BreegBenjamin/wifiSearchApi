using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Responses;

namespace WiFiSharing.Application.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<FavoriteResponseData> AddFavoriteNewtworkByUserAsync(FavoriteDto favoriteDto);
        Task<FavoriteResponseData> UpdateFavoriteNewtworkAsync(FavoriteDto favorite);
        Task<FavoriteResponseData> DeleteFavoriteNewtworkByIdAsync(int favoriteId);
        Task<FavoriteResponseData> GetFavoriteNewtworkByUserIdAsync(int userId);
        Task<FavoriteResponseData> GetAllFavoriteNetWorksAsync();
    }
}
