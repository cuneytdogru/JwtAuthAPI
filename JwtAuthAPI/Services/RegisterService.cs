using JwtAuthAPI.DataAccess;
using JwtAuthAPI.Dtos;
using JwtAuthAPI.Models;
using JwtAuthAPI.Services.Interfacces;

namespace JwtAuthAPI.Services
{
    public class RegisterService : IRegisterService
    {
        public Task<UserDto> RegisterUser(RegisterUserRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName))
                throw new Exception("Username is empty!");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new Exception("Password is empty!");

            if (ListStore.Users.Any(x => x.UserName == dto.UserName))
                throw new Exception("Username already exists!");

            var user = new User(dto.UserName, dto.Password, dto.FullName, dto.Email, dto.Mobile);

            ListStore.Users.Add(user);

            return Task.FromResult(new UserDto(user));
        }
    }
}