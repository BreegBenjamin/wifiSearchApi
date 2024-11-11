using Microsoft.AspNetCore.Mvc;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;

namespace WifiSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WiFiNetworkController : ControllerBase
    {
        private readonly IWiFiNetworkRepository _wiFiNetworkRepository;
        public WiFiNetworkController(IWiFiNetworkRepository wiFiNetworkRepository)
        {
            _wiFiNetworkRepository = wiFiNetworkRepository;
        }

        // GET: api/wifinetwork/GetAllWifi
        [HttpGet("GetAllWifi")]
        public async Task<IActionResult> GetAllWiFiNetworks()
        {
            var response = await _wiFiNetworkRepository.GetAllActiveWiFiNetworksAsync();
            return Ok(response);
        }

        // GET: api/wifinetwork/GetWiFiById/{d}
        [HttpGet("getWiFiById/{id}")]
        public async Task<IActionResult> GetWiFiNetworkById(int id)
        {
            var response = await _wiFiNetworkRepository.GetWiFiNetworkByIdAsync(id);
            return Ok(response);
        }

        // POST: api/wifinetwork/addWifi
        [HttpPost("addWifi")]
        public async Task<IActionResult> AddWiFiNetwork(WiFiNetworkDto wiFiNetworkDto)
        {
            var response = await _wiFiNetworkRepository.AddWiFiNetworkAsync(wiFiNetworkDto);
            return Ok(response);
        }

        // PUT: api/wifinetwork/{id}
        [HttpPut("updateWiFiNetwork")]
        public async Task<IActionResult> UpdateWiFiNetwork(WiFiNetworkDto wiFiNetworkDto)
        {
            var response = await _wiFiNetworkRepository.UpdateWiFiNetworkAsync(wiFiNetworkDto);
            return Ok(response);
        }

        // DELETE: api/wifinetwork/deleteWiFiNetwork/{id}
        [HttpDelete("deleteWiFiNetwork/{id}")]
        public async Task<IActionResult> DeleteWiFiNetwork(int id)
        {
            var response = await _wiFiNetworkRepository.DeleteWiFiNetworkAsync(id);
            return Ok();
        }
    }
}
