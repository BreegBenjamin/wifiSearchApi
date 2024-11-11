using WiFiSharing.Application.DTOs;

namespace WiFiSharing.Application.Responses
{
    public class ResponseData<T>
    {
        public string ? MessageResponse { get; set; }
        public bool IsSuccess { get; set; }
    }
    public class UserResponseData : ResponseData<UserDto>
    {
        public UserDto ? UserData { get; set; }
        public IEnumerable<UserDto>? UsersData { get; set; } = [];
    }

    public class FavoriteResponseData : ResponseData<FavoriteDto>
    {
        public FavoriteDto ? FavoriteData { get; set; }
        public IEnumerable<FavoriteDto>? FavoritesData { get; set; } = [];
    }

    public class AdminResponseData : ResponseData<AdminDto>
    {
        public AdminDto? AdminDto { get; set; }
        public IEnumerable<AdminDto>? AdminsDto { get; set; } = [];
    }

    public class ReputationResponseData : ResponseData<ReputationDto>
    {
        public ReputationDto? ReputationDto { get; set; }
        public IEnumerable<ReputationDto>? reputationsDto { get; set; } = [];
    }
    public class WifiNetworkResponseData : ResponseData<WiFiNetworkDto>
    {
        public WiFiNetworkDto? WiFiNetworkDto { get; set; }
        public IEnumerable<WiFiNetworkDto>? WiFiNetworksDto { get; set; } = [];

    }
    public class ReportResponseData : ResponseData<ReportDto>
    {
        public ReportDto? ReportDto { get; set; }
        public IEnumerable<ReportDto>? ReportsDto {get;set;} = [];
    }
}
