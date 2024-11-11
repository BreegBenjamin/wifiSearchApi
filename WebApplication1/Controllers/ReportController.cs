using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;

namespace WifiSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        // GET: api/report/wifinetwork/{wifiId}
        [HttpGet("reportByWifinetwork/{wifiId}")]
        public async Task<IActionResult> GetReportsByWiFiNetwork(int wifiId)
        {
            var response = await _reportRepository.GetReportsByWiFiNetworkAsync(wifiId);
            return Ok(response);
        }

        // GET: api/report/getAllReports
        [HttpGet("getAllReports")]
        public async Task<IActionResult> GetAllReportsAsync()
        {
            var response = await _reportRepository.GetAllReportsAsync();
            return Ok(response);
        }

        // POST: api/addReport
        [HttpPost("addReport")]
        public async Task<IActionResult> AddReportAsync(ReportDto reportDto)
        {
            var response = await _reportRepository.AddReportAsync(reportDto);
            return Ok(response);
        }

        // PUT: api/report/{id}
        [HttpPut("updateReport")]
        public async Task<IActionResult> UpdateReportAsync(ReportDto reportDto)
        {
            var response = await _reportRepository.UpdateReportAsync(reportDto);
            return Ok(response);
        }

        // DELETE: api/report/{id}
        [HttpDelete("deleteReport/{reportId}")]
        public async Task<IActionResult> DeleteReport(int reportId)
        {
            var response = await _reportRepository.DeleteReportAsync(reportId);
            return Ok(response);
        }
    }
}
