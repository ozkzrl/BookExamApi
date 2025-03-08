using BookExam.Application.Interfaces;
using BookExam.Application.DTOs.User;
using BookExam.Domain.Entities;
using BookExam.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExam.Application.Services
{
    public class UserService : IUserService
    {
        private readonly BookExamDbContext _context;

        public UserService(BookExamDbContext context)
        {
            _context = context;
        }

        // Kullanıcı ID'ye göre kullanıcı bilgilerini al
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username
            };
        }

        // Tüm kullanıcıları listele
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            return await _context.Users
                                 .Select(user => new UserDto
                                 {
                                     Id = user.Id,
                                     Username = user.Username
                                 })
                                 .ToListAsync();
        }

        // Yeni bir kullanıcı ekle
        public async Task AddUserAsync(RegisterUserDto registerUserDto)
        {
            var user = new User
            {
                Username = registerUserDto.Username,
                Password = registerUserDto.Password // Şifre güvenli bir şekilde saklanmalıdır
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
