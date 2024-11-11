using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Responses;

namespace WiFiSharing.Application.Interfaces
{
    public interface IWiFiNetworkRepository
    {
        Task<WifiNetworkResponseData> GetAllActiveWiFiNetworksAsync();
        Task<WifiNetworkResponseData> GetWiFiNetworkByIdAsync(int id);
        Task<WifiNetworkResponseData> AddWiFiNetworkAsync(WiFiNetworkDto wifiNetworkDto);
        Task<WifiNetworkResponseData> UpdateWiFiNetworkAsync(WiFiNetworkDto wifiNetwork);
        Task<WifiNetworkResponseData> DeleteWiFiNetworkAsync(int wifiId);
        Task<WifiNetworkResponseData> GetWiFiNetworksByLocationAsync(decimal latitude, decimal longitude, double radius);
        Task<WifiNetworkResponseData> GetWiFiNetworksByQualityAsync(int minQuality);
        Task<WifiNetworkResponseData> GetWiFiNetworksBySecurityLevelAsync(string securityLevel);
        Task<WifiNetworkResponseData> GetWiFiNetworksBySpeedAsync(int minSpeed);
    }
}
