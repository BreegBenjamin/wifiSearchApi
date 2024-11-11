using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;
using WiFiSharing.Application.Responses;
using WiFiSharing.Domain.Entities;
using WiFiSharing.Infrastructure.DataAccess;

namespace WiFiSharing.Infrastructure.Repositories
{
    public class ReputationRepository : IReputationRepository
    {
        private readonly WifiSearchContext _context;
        private readonly IMapper _mapper;
        public ReputationRepository(WifiSearchContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReputationResponseData> AddCommentAsync(ReputationDto reputationDto)
        {
            try
            {
                Reputation reputation = _mapper.Map<Reputation>(reputationDto);
                await _context.Reputations.AddAsync(reputation);
                int result = await _context.SaveChangesAsync();
                string ms = (result > 1) ? "OK" : "Error";
                return DataResponse(result > 1, ms, _mapper.Map<ReputationDto>(reputation));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReputationResponseData> DeleteCommentAsync(int reputationId)
        {
            try
            {
                Reputation? reputation = await _context.Reputations.Where(x => x.ReputationId == reputationId).FirstOrDefaultAsync();
                if (reputation != null)
                {
                    _context.Reputations.Remove(reputation);
                    int result = await _context.SaveChangesAsync();
                    string ms = (result > 1) ? "Eliminado" : "Error";
                    return DataResponse(result > 1, ms, new ReputationDto());
                }
                else 
                {
                    return DataResponse(false, "Error", new ReputationDto());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReputationResponseData> GetAllCommentsAsync()
        {
            try
            {
                var comments = await _context.Reputations.ToListAsync();
                return new ReputationResponseData 
                { 
                    IsSuccess = true,
                    MessageResponse = (comments.Any()) ? "OK" : "NO comments",
                    reputationsDto = _mapper.Map<IEnumerable<ReputationDto>>(comments)
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReputationResponseData> GetCommentByIdAsync(int reputationId)
        {
            try
            {
                var reputation = await _context.Reputations.Where(x => x.ReputationId == reputationId).FirstOrDefaultAsync();

                if (reputation != null)
                {
                    ReputationDto rDto = _mapper.Map<ReputationDto>(reputation);
                    return DataResponse(true, "OK", rDto);
                }
                else 
                {
                    return DataResponse(false, "Comment don´t exist", new ReputationDto());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReputationResponseData> UpdateCommentAsync(ReputationDto reputationDto)
        {
            try
            {
                Reputation? reputation = await _context.Reputations.Where(x => x.ReputationId == reputationDto.ReputationId).FirstOrDefaultAsync();
                if (reputation != null)
                {
                    reputation = _mapper.Map<Reputation>(reputationDto);
                    int resut = await _context.SaveChangesAsync();
                    string ms = (resut > 1) ? "OK" : "Error";
                    return DataResponse(resut > 1, ms, reputationDto);
                }
                else 
                {
                    return DataResponse(false, "", new ReputationDto());
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private ReputationResponseData DataResponse(bool isSuccess, string ms, ReputationDto dto) 
        {
            return new ReputationResponseData 
            {
            
                IsSuccess = isSuccess,
                MessageResponse = ms,
                ReputationDto = dto
            };
        }
    }
}
