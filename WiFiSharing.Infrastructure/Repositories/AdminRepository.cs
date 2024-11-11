using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;
using WiFiSharing.Application.Responses;
using WiFiSharing.Domain.Entities;
using WiFiSharing.Infrastructure.DataAccess;

namespace WiFiSharing.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly WifiSearchContext _context;
        private readonly IMapper _mapper;
        public AdminRepository(WifiSearchContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AdminResponseData> AddAdminAsync(int userId, string adminLevel)
        {
            try
            {
                Admin? newAdmin = await _context.Admins.Where(x=> x.UserId == userId).FirstOrDefaultAsync();

                if (!newAdmin.Equals(null))
                {
                    var admin = new Admin
                    {
                        CreatedAt = DateTime.UtcNow,
                        Role = adminLevel,
                        UserId = userId
                    };
                    _context.Admins.Add(admin);

                    int result = await _context.SaveChangesAsync();

                    return new AdminResponseData
                    {
                        AdminDto = _mapper.Map<AdminDto>(admin),
                        IsSuccess = result > 1,
                        MessageResponse = (result > 1) ? "OK" : "Error"
                    };
                }
                else 
                {
                    return new AdminResponseData
                    {
                        AdminDto = new AdminDto(),
                        IsSuccess = false,
                        MessageResponse =  "Error to add admin"
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<AdminResponseData> GetAdminByUserIdAsync(int userId)
        {
            try
            {
                Admin? admin = await _context.Admins.Where(x => x.UserId == userId).FirstOrDefaultAsync();

                if (admin != null)
                {
                    return new AdminResponseData
                    {
                        AdminDto = _mapper.Map<AdminDto>(admin),
                        IsSuccess = true,
                        MessageResponse = "OK"
                    };

                }
                else 
                {
                    return new AdminResponseData
                    {
                        AdminDto = new AdminDto(),
                        IsSuccess = false,
                        MessageResponse = "Error to get admin"
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<AdminResponseData> GetAllAdminsAsync()
        {
            try
            {
                var admins = await _context.Admins.ToListAsync();

                if (admins != null)
                {
                    return new AdminResponseData
                    {
                        AdminsDto = _mapper.Map<IEnumerable<AdminDto>>(admins),
                        IsSuccess = true,
                        MessageResponse = "OK"
                    };

                }
                else
                {
                    return new AdminResponseData
                    {
                        AdminDto = new AdminDto(),
                        IsSuccess = false,
                        MessageResponse = "Error to get admin"
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<AdminResponseData> UpdateAdminAsync(int userId, string adminLevel)
        {
            try
            {
                Admin? admin = await _context.Admins.Where(x => x.UserId == userId).FirstOrDefaultAsync();

                if (admin != null)
                {
                    var newAdmin = new Admin()
                    {
                        CreatedAt = DateTime.Now,
                        Role = adminLevel,
                        UserId = userId,
                    };
                    _context.Admins.Add(admin);
                    int result = await _context.SaveChangesAsync();

                    return new AdminResponseData
                    {
                        AdminDto = _mapper.Map<AdminDto>(newAdmin),
                        IsSuccess = result > 1,
                        MessageResponse = (result > 1) ? "" : ""
                    };
                }
                else 
                {
                    return new AdminResponseData() 
                    {
                        AdminDto = new AdminDto(),
                        IsSuccess = false,
                        MessageResponse = "Error"
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<AdminResponseData> DeleteAdminAsync(int userId)
        {
            try
            {
                Admin? admin = await _context.Admins.Where(x=> x.UserId == userId).FirstOrDefaultAsync();
                if (admin != null)
                {
                    User? user = await _context.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
                    user.IsAdmin = false;

                    _context.Admins.Remove(admin);
                    int result = await _context.SaveChangesAsync();

                    return new AdminResponseData()
                    {
                        AdminDto = _mapper.Map<AdminDto>(admin),
                        IsSuccess = result > 1,
                        MessageResponse = (result > 1) ? "Success" : "Error"
                    };
                }
                else 
                {
                    return new AdminResponseData()
                    {
                        AdminDto = new AdminDto(),
                        IsSuccess = false,
                        MessageResponse = ""
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
