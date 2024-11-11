using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;
using WiFiSharing.Application.Responses;
using WiFiSharing.Domain.Entities;
using WiFiSharing.Infrastructure.DataAccess;

namespace WiFiSharing.Infrastructure.Repositories
{
    public class WiFiNetworkRepository : IWiFiNetworkRepository
    {
        private readonly WifiSearchContext _context;
        private readonly IMapper _mapper;
        public WiFiNetworkRepository(WifiSearchContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WifiNetworkResponseData> AddWiFiNetworkAsync(WiFiNetworkDto wifiNetworkDto)
        {
            try
            {
                WiFiNetwork wiFiNetwork = _mapper.Map<WiFiNetwork>(wifiNetworkDto);
                await _context.WiFiNetworks.AddAsync(wiFiNetwork);
                int saveResult = await _context.SaveChangesAsync();
                string ms = (saveResult > 1) ? "Red added successfull" : "Error to add wifi red";

                return WifiNetworkResponse(saveResult > 1, ms, wifiNetworkDto); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<WifiNetworkResponseData> DeleteWiFiNetworkAsync(int wifiId)
        {
            try
            {
                WiFiNetwork? wifi = await _context.WiFiNetworks.Where(x=> x.WiFiId == wifiId).FirstOrDefaultAsync();
                
                if (!wifi.Equals(null))
                {
                    wifi.IsActive = false;
                    _context.WiFiNetworks.Remove(wifi);
                    int saveResult = await _context.SaveChangesAsync();

                    return new WifiNetworkResponseData
                    {
                        IsSuccess = saveResult > 1,
                        MessageResponse = (saveResult > 1) ? "Wi-fi red deleted" : "Error to delete wi-fi red",
                        WiFiNetworkDto = _mapper.Map<WiFiNetworkDto>(wifi),
                    };
                }
                else 
                {
                    return new WifiNetworkResponseData
                    {
                        IsSuccess = false,
                        MessageResponse = "Error to delete wifi red",
                        WiFiNetworkDto = new WiFiNetworkDto(),
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WifiNetworkResponseData> GetAllActiveWiFiNetworksAsync()
        {
            try
            {
                IEnumerable<WiFiNetwork> wifiReds = await _context.WiFiNetworks.Where(x=> x.IsActive == true).ToListAsync();

                if (!wifiReds.Equals(null))
                {
                    return new WifiNetworkResponseData
                    {
                        WiFiNetworksDto = _mapper.Map<IEnumerable<WiFiNetworkDto>>(wifiReds),
                        IsSuccess = true,
                        MessageResponse = "OK"
                    };
                }
                else 
                {
                    return new WifiNetworkResponseData 
                    {
                        MessageResponse = "Not have reds",
                        IsSuccess = false,
                        WiFiNetworksDto = []
                    
                    };
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WifiNetworkResponseData> GetWiFiNetworkByIdAsync(int id)
        {
            try
            {
                WiFiNetwork? wifi = await _context.WiFiNetworks.Where(x=> x.WiFiId == id).FirstOrDefaultAsync();

                if (!wifi.Equals(null))
                {
                    var wifiMap = _mapper.Map<WiFiNetworkDto>(wifi);
                    return WifiNetworkResponse(true, "OK", wifiMap);
                }
                else 
                {
                    return WifiNetworkResponse(false, "Red don´t exist", new WiFiNetworkDto());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<WifiNetworkResponseData> GetWiFiNetworksByLocationAsync(decimal latitude, decimal longitude, double radius)
        {
            try
            {
                var wifiNewtworks = await _context.WiFiNetworks.Where(
                    x=> x.Latitude == latitude && x.Longitude == longitude).ToListAsync();

                return new WifiNetworkResponseData
                {
                    IsSuccess = true,
                    MessageResponse = "OK",
                    WiFiNetworksDto = _mapper.Map<IEnumerable<WiFiNetworkDto>>(wifiNewtworks)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<WifiNetworkResponseData> GetWiFiNetworksByQualityAsync(int minQuality)
        {
            throw new NotImplementedException();
        }

        public Task<WifiNetworkResponseData> GetWiFiNetworksBySecurityLevelAsync(string securityLevel)
        {
            throw new NotImplementedException();
        }

        public Task<WifiNetworkResponseData> GetWiFiNetworksBySpeedAsync(int minSpeed)
        {
            throw new NotImplementedException();
        }

        public Task<WifiNetworkResponseData> UpdateWiFiNetworkAsync(WiFiNetworkDto wifiNetwork)
        {
            throw new NotImplementedException();
        }

        private WifiNetworkResponseData WifiNetworkResponse(bool isSuccess, string ms, WiFiNetworkDto wifiDto) 
        {
            return new WifiNetworkResponseData
            {
                IsSuccess = isSuccess,
                MessageResponse = ms,
                WiFiNetworkDto = wifiDto,
            };
        }
    }
}
