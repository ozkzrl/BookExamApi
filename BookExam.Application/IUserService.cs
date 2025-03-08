using BookExam.Application.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookExam.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task AddUserAsync(RegisterUserDto registerUserDto);
    }
}
