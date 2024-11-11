using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;
using WiFiSharing.Application.Responses;
using WiFiSharing.Domain.Entities;
using WiFiSharing.Infrastructure.DataAccess;

namespace WiFiSharing.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly WifiSearchContext _context;
        private readonly IMapper _mapper;

        public FavoriteRepository(WifiSearchContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FavoriteResponseData> AddFavoriteNewtworkByUserAsync(FavoriteDto favoriteDto)
        {
            try
            {
                Favorite favorite = _mapper.Map<Favorite>(favoriteDto);
                 await _context.Favorites.AddAsync(favorite);
                int result = await _context.SaveChangesAsync();

                return new FavoriteResponseData
                {
                    IsSuccess = result > 1,
                    FavoriteData = favoriteDto,
                    MessageResponse = (result > 1)  ?  "" : ""
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FavoriteResponseData> DeleteFavoriteNewtworkByIdAsync(int favoriteId)
        {
            try
            {
                Favorite? favorite = await _context.Favorites.Where(x=> x.FavoriteId == favoriteId).FirstOrDefaultAsync();
                _context.Favorites.Remove(favorite);
                int result = await _context.SaveChangesAsync();

                return new FavoriteResponseData 
                {
                    FavoriteData = new FavoriteDto(),
                    IsSuccess = result > 1,
                    MessageResponse = (result > 1) ? "" : ""
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FavoriteResponseData> GetAllFavoriteNetWorksAsync()
        {
            try
            {
                var favorites = await _context.WiFiNetworks.ToListAsync();
                return new FavoriteResponseData
                {
                    IsSuccess = favorites.Any(),
                    FavoritesData = _mapper.Map<IEnumerable<FavoriteDto>>(favorites),
                    MessageResponse = (favorites.Any()) ? "OK" : "Error",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FavoriteResponseData> GetFavoriteNewtworkByUserIdAsync(int favoriteId)
        {
            try
            {
                Favorite? favorite = await _context.Favorites.Where(x => x.FavoriteId == favoriteId).FirstOrDefaultAsync();

                return new FavoriteResponseData 
                {
                    FavoriteData = _mapper.Map<FavoriteDto>(favorite),
                    IsSuccess = (favorite != null),
                    MessageResponse = (favorite != null) ? "OK" : "Error"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FavoriteResponseData> UpdateFavoriteNewtworkAsync(FavoriteDto favoriteDto)
        {
            try
            {
                Favorite?  favorite = await _context.Favorites.Where(x=> x.FavoriteId == favoriteDto.FavoriteId).FirstOrDefaultAsync();
                if (favorite != null)
                {
                    favorite = _mapper.Map<Favorite>(favoriteDto);
                    int result = await _context.SaveChangesAsync();

                    return new FavoriteResponseData
                    {
                        FavoriteData = favoriteDto,
                        IsSuccess = result > 1,
                        MessageResponse = (result > 1) ? "OK" : "Error"
                    };
                }
                else 
                {
                    return new FavoriteResponseData
                    {
                        FavoriteData = new FavoriteDto(),
                        IsSuccess = false,
                        MessageResponse =  "Error"
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
