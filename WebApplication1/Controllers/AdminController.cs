using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WiFiSharing.Application.Interfaces;

namespace WifiSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        public AdminController(IAdminRepository adminRepository)
        {
                _adminRepository = adminRepository;
        }

        // GET: api/admin/getAllAdmins
        [HttpGet("getAllAdmins")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var response = await _adminRepository.GetAllAdminsAsync();
            return Ok();
        }

        //GET: api/admin/getAdminById/{id}
        [HttpGet("getAdminById/{userId}")]
        public async Task<IActionResult> GetAdminByIdAsync(int userId)
        {
            var response = await _adminRepository.GetAdminByUserIdAsync(userId);
            return Ok(response);
        }

        //GET: api/admin/addAdmin/{id}/{adminLevel}
        [HttpGet("addAdmin/{userId}/{adminLevel}")]
        public async Task<IActionResult> AddAdminAsync(int userId, string adminLevel)
        {
            var response = await _adminRepository.AddAdminAsync(userId, adminLevel);
            return Ok();
        }
        //GET : api/admin/updateAdmin/{userId}/{adminLevel}
        [HttpGet("updateAdmin/{userId}/{adminLevel}")]
        public async Task<IActionResult> UpdateAdminAsync(int userId, string adminLevel)
        {
            var response = await _adminRepository.UpdateAdminAsync(userId, adminLevel);
            return Ok(response);
        }

        // Delete : api/admin/deleteAdmin/{userId
        [HttpDelete("deleteAdmin/{userId}")]
        public async Task<IActionResult> DeleteAdminAsyn(int userId)
        {
            var response = await _adminRepository.DeleteAdminAsync(userId);
            return Ok(response);
        }
    }
}
