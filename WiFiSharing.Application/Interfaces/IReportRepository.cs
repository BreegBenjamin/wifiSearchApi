using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Responses;

namespace WiFiSharing.Application.Interfaces
{
    public interface IReportRepository
    {
        Task<ReportResponseData> GetReportsByWiFiNetworkAsync(int networkId);
        Task<ReportResponseData> GetAllReportsAsync();
        Task<ReportResponseData> AddReportAsync(ReportDto reportDto);
        Task<ReportResponseData> UpdateReportAsync(ReportDto reportDto);
        Task<ReportResponseData> DeleteReportAsync(int reportId);
    }
}
