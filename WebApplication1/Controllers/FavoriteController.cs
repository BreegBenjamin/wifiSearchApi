using Microsoft.AspNetCore.Mvc;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;

namespace WifiSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        // GET: api/favorite/getFavoriteNewtworkByUserId/{userId}
        [HttpGet("getFavoriteNewtworkByUserId/{userId}")]
        public async Task<IActionResult> GetFavoriteNewtworkByUserId(int userId)
        {
            var response = await _favoriteRepository.GetFavoriteNewtworkByUserIdAsync(userId);
            return Ok(response);
        }

        // GET: api/favorite/getAllFavoriteNetWorks
        [HttpGet("getAllFavoriteNetWorks")]
        public async Task<IActionResult> GetAllFavoriteNetWorks()
        {
            var response = await _favoriteRepository.GetAllFavoriteNetWorksAsync();
            return Ok(response);
        }

        // POST: api/favorite/addFavoriteNewtworkByUser
        [HttpPost("addFavoriteNewtworkByUser")]
        public async Task<IActionResult> AddFavoriteNewtworkByUser(FavoriteDto favoriteDto)
        {
            var response = await _favoriteRepository.AddFavoriteNewtworkByUserAsync(favoriteDto);
            return Ok(response);
        }

        // PUT: api/favorite/updateFavoriteNewtwork/{id}
        [HttpPut("updateFavoriteNewtwork/{id}")]
        public async Task<IActionResult> UpdateFavoriteNewtwork(FavoriteDto favoriteDto)
        {
            var response = await _favoriteRepository.UpdateFavoriteNewtworkAsync(favoriteDto);
            return Ok(response);
        }

        // DELETE: api/favorite/deleteFavoriteNewtworkById/{id}
        [HttpDelete("deleteFavoriteNewtworkById/{id}")]
        public async Task<IActionResult> DeleteFavoriteNewtworkById(int favoriteId)
        {
            var response = await _favoriteRepository.DeleteFavoriteNewtworkByIdAsync(favoriteId);
            return Ok(response);
        }
    }
}
