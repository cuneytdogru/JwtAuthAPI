using JwtAuthAPI.Dtos;
using JwtAuthAPI.Models;

namespace JwtAuthAPI.Services.Interfacces
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto dto);

        public Task Logout(string token);
    }
}