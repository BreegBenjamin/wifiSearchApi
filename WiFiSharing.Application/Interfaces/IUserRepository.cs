using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Responses;

namespace WiFiSharing.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<UserResponseData> GetAllUsersAsync();
        Task<UserResponseData> GetUserByIdAsync(int id);
        Task<UserResponseData> AddUserAsync(UserDto user);
        Task<UserResponseData> UpdateUserAsync(UserDto user);
        Task<UserResponseData> DeleteUserAsync(UserDto userDto);
        Task<UserResponseData> LoginUser(LoginData login);
    }
}
