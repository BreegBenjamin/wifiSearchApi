using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;
using WiFiSharing.Application.Responses;
using WiFiSharing.Domain.Entities;
using WiFiSharing.Infrastructure.DataAccess;

namespace WiFiSharing.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WifiSearchContext _context;
        private readonly IMapper _mapper;

        public UserRepository(WifiSearchContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserResponseData> AddUserAsync(UserDto userDto)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                var newUser = await _context.Users.AddAsync(user);
                int result = await _context.SaveChangesAsync();

                return new UserResponseData()
                {
                    UserData = userDto,
                    IsSuccess = result > 0,
                    MessageResponse = (result > 0) ? "User add success" : "Error in the process"
                };
            }

            catch (Exception)
            {

                throw;
            }
        } 

        public async Task<UserResponseData> DeleteUserAsync(UserDto userDto)
        {
            try
            {
                User? user = await _context.Users.Where(x => x.UserId == userDto.UserId).FirstOrDefaultAsync();

                if (!user.Equals(null))
                {
                    _context.Users.Remove(user);
                    int result = await _context.SaveChangesAsync();

                    return new UserResponseData()
                    {
                        UserData = _mapper.Map<UserDto>(user),
                        IsSuccess = result > 0,
                        MessageResponse = (result > 0) ? "User deleted successful" : "Error to delete user",
                    };

                }
                else 
                {
                    return new UserResponseData()
                    {
                        IsSuccess = false,
                        MessageResponse = "Error in the application",
                        UserData = new UserDto()
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserResponseData> GetAllUsersAsync()
        {
            try
            {
                IEnumerable<User> users = await _context.Users.ToListAsync();

                IEnumerable<UserDto> usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

                return new UserResponseData()
                {
                    UsersData = usersDto,
                    IsSuccess = true,
                    MessageResponse = "OK"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserResponseData> GetUserByIdAsync(int id)
        {
            try
            {
                User? user = await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();

                UserDto userDto = _mapper.Map<UserDto>(user);

                return new UserResponseData()
                {
                    UserData = userDto,
                    IsSuccess = true,
                    MessageResponse = "OK"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserResponseData> LoginUser(LoginData login)
        {
            try
            {
                User? dbUser = await _context.Users.Where(
                    x => x.Email == login.Email ||
                    x.PasswordHash == login.PasswordHash)
                    .FirstOrDefaultAsync();

                if (!dbUser.Equals(null))
                {
                    return new UserResponseData()
                    {
                        IsSuccess = true,
                        MessageResponse =  "OK",
                        UserData = _mapper.Map<UserDto>(dbUser)
                    };
                }
                else
                {
                    return new UserResponseData()
                    {
                        IsSuccess = false,
                        MessageResponse = "Error to login",
                        UserData = new UserDto()
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserResponseData> UpdateUserAsync(UserDto user)
        {
            try
            {
                User ? dbUser = await _context.Users.Where(x=> x.UserId == user.UserId).FirstOrDefaultAsync();
                if (!dbUser.Equals(null))
                {
                    dbUser = _mapper.Map<User>(user);
                    int result = await _context.SaveChangesAsync();

                    return new UserResponseData()
                    {
                        IsSuccess = result > 1,
                        MessageResponse = (result > 1) ? "User updated succesfull" : "Error to update the user",
                        UserData = user
                    };
                }
                else 
                {
                    return new UserResponseData()
                    {
                        IsSuccess = false,
                        MessageResponse = "Error to update the user",
                        UserData = new UserDto()
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
