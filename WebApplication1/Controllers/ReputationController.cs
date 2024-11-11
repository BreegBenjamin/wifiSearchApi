using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;

namespace WifiSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReputationController : ControllerBase
    {
        private readonly IReputationRepository _reputationRepository;
        public ReputationController(IReputationRepository reputationRepository)
        {
            _reputationRepository = reputationRepository;
        }

        // GET: api/reputation/getCommentById/{commentId}
        [HttpGet("getCommentById/{commentId}")]
        public async Task<IActionResult> GetCommentByIdAsync(int commentId)
        {
            var response = await _reputationRepository.GetCommentByIdAsync(commentId);
            return Ok(response);
        }

        // GET: api/reputation/getCommentById/{commentId}
        [HttpGet("getAllComments")]
        public async Task<IActionResult> GetAllCommentsAsync()
        {
            var response = await _reputationRepository.GetAllCommentsAsync();
            return Ok(response);
        }

        // POST: api/reputation
        [HttpPost("addComment")]
        public async Task<IActionResult> AddCommentAsync(ReputationDto reputationDto)
        {
            var response = await _reputationRepository.AddCommentAsync(reputationDto);  
            return Ok(response);
        }

        // PUT: api/reputation/{id}
        [HttpPut("updateComment")]
        public async Task<IActionResult> UpdateCommentAsync(ReputationDto reputationDto)
        {
            var response = await _reputationRepository.UpdateCommentAsync(reputationDto);
            return Ok(response);
        }

        // DELETE: api/reputation/{id}
        [HttpDelete("deleteComment/{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var response = await _reputationRepository.DeleteCommentAsync(commentId);
            return Ok(response);
        }
    }
}
