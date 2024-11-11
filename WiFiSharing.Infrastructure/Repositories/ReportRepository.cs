using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;
using WiFiSharing.Application.Responses;
using WiFiSharing.Domain.Entities;
using WiFiSharing.Infrastructure.DataAccess;

namespace WiFiSharing.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly WifiSearchContext _context;
        private readonly IMapper _mapper;
        public ReportRepository(WifiSearchContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReportResponseData> AddReportAsync(ReportDto reportDto)
        {
            try
            {
                Report report = _mapper.Map<Report>(reportDto);
                await _context.Reports.AddAsync(report);

                int result = await _context.SaveChangesAsync();

                return new ReportResponseData 
                {
                    IsSuccess = result > 1,
                    MessageResponse = (result > 1) ? "OK" : "Error",
                    ReportDto = reportDto
                }; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReportResponseData> DeleteReportAsync(int reportId)
        {
            try
            {
                Report? report = await _context.Reports.Where(x => x.ReportId == reportId).FirstOrDefaultAsync();
                if (report != null)
                {
                    _context.Reports.Remove(report);
                    int result = await _context.SaveChangesAsync();
                    return new ReportResponseData
                    {
                        IsSuccess = result > 1,
                        MessageResponse = (result > 1) ? "OK" : "Error",
                        ReportDto = new ReportDto()
                    };
                }
                else 
                {
                    return new ReportResponseData
                    {
                        IsSuccess = false,
                        MessageResponse = "Error",
                        ReportDto = new ReportDto()
                    };
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReportResponseData> GetAllReportsAsync()
        {
            try
            {
                var reports = await _context.Reports.ToListAsync();

                return new ReportResponseData
                {
                    ReportsDto = _mapper.Map<IEnumerable<ReportDto>>(reports),
                    IsSuccess = reports.Any(),
                    MessageResponse = (reports.Any()) ? "OK" : "Error", 
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReportResponseData> GetReportsByWiFiNetworkAsync(int networkId)
        {
            try
            {
                var report = await _context.Reports.Where(x => x.WiFiId == networkId).FirstOrDefaultAsync();

                return new ReportResponseData
                {
                    IsSuccess = report != null,
                    MessageResponse = (report != null) ? "OK" : "Error",
                    ReportDto = _mapper.Map<ReportDto>(report),
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReportResponseData> UpdateReportAsync(ReportDto reportDto)
        {
            try
            {
                Report? repor = await _context.Reports.Where(x => x.ReportId == reportDto.ReportId).FirstOrDefaultAsync();
                if (repor != null)
                {
                    repor = _mapper.Map<Report>(reportDto);
                    int result = await _context.SaveChangesAsync();

                    return new ReportResponseData
                    {
                        IsSuccess = result > 1,
                        MessageResponse = (result > 0) ? "OK" : "Error",
                        ReportDto = reportDto
                    };
                }
                else 
                {
                    return new ReportResponseData
                    {
                        IsSuccess = false,
                        MessageResponse = "Error",
                        ReportDto = new ReportDto()
                    };
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
