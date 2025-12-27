using BCrypt.Net;
using ecotrack_backend.Dto;
using ecotrack_backend.Interfaces;
using ecotrack_backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace ecotrack_backend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<LoginResponse> login(LoginRequest request)
        {
            var user = _appDbContext.Users.FirstOrDefault(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Credenziali errate");

            var key = Encoding.ASCII.GetBytes("5x4cB;2HDc}SJ|bk5A=dIk.>k#%7Hc)~");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponse response = new() { 
                Token = tokenHandler.WriteToken(token), 
                Id = user.Id, 
                Email = user.Email 
            };

            return response;
        }

        public async Task<RegisterResponse> register(RegisterRequest request)
        {
            User user = new();
            user.Email = request.Email;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Name = request.Name;
            user.Surname = request.Surname;
            user.DateBorn = request.DateBorn;
            user.PlaceBorn = request.PlaceBorn;

            try {
                _appDbContext.Users.Add(user);
                await _appDbContext.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new Exception("Error registering user: " + ex.Message);
            }

            RegisterResponse response = new();
            response.Id = user.Id;
            response.Email = user.Email;
            response.Name = user.Name;
            response.Surname = user.Surname;
            response.DateBorn = user.DateBorn;
            response.PlaceBorn = user.PlaceBorn;
            return response;
        }
    }
}
