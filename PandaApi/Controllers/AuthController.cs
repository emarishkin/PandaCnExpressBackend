using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PandaApi.Data;
using PandaApi.Dtos;
using PandaApi.Models;
using System.Security.Cryptography;
using System.Text;

namespace PandaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            // Проверяем, существует ли уже такой email
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (existingUser != null)
            {
                return BadRequest("Пользователь с таким email уже существует.");
            }

            // Хешируем пароль
            var passwordHash = ComputeSha256Hash(dto.Password);

            // Создаём нового пользователя
            var user = new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PasswordHash = passwordHash,
                Status = dto.Status,
                Phone = dto.Phone,
                Country = dto.Country
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Регистрация прошла успешно.");
        }

        // Хеширование пароля (SHA256)
        private static string ComputeSha256Hash(string rawData)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            var builder = new StringBuilder();
            foreach (var b in bytes)
                builder.Append(b.ToString("x2"));

            return builder.ToString();
        }
    }
}
