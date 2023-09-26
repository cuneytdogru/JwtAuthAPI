using JwtAuthAPI.Dtos;
using JwtAuthAPI.Models;

namespace JwtAuthAPI.Services.Interfacces
{
    public interface IRegisterService
    {
        public Task<UserDto> RegisterUser(RegisterUserRequestDto dto);
    }
}