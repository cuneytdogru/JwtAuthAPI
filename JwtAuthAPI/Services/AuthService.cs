using JwtAuthAPI.DataAccess;
using JwtAuthAPI.Dtos;
using JwtAuthAPI.Models;
using JwtAuthAPI.Services.Interfacces;

namespace JwtAuthAPI.Services
{
    public class AuthService : IAuthService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto dto)
        {
            var user = GetUser(dto.UserName, dto.Password);

            if (user == null)
                throw new Exception("Invalid username or password!");

            var existingToken = GetActiveTokenFromUser(user.Id);

            if (existingToken != null)
                existingToken.Disable();

            var token = new Token(user);

            ListStore.Tokens.Add(token);

            return Task.FromResult(new LoginResponseDto(token.Key));
        }

        public Task Logout(string key)
        {
            var existingToken = GetActiveTokenFromKey(key);

            if (existingToken != null)
                existingToken.Disable();

            return Task.CompletedTask;
        }

        private User? GetUser(string username, string password)
        {
            var user = ListStore.Users
                .Where(x => x.UserName == username)
                .Where(x => x.Password == password.GetHashCode().ToString())
                .SingleOrDefault();

            return user;
        }

        private Token? GetActiveTokenFromUser(Guid userId)
        {
            var token = ListStore.Tokens
                .Where(x => x.UserId == userId)
                .Where(x => !x.IsExpired)
                .SingleOrDefault();

            return token;
        }

        private Token? GetActiveTokenFromKey(string key)
        {
            var token = ListStore.Tokens
                .Where(x => x.Key == key)
                .Where(x => !x.IsExpired)
                .SingleOrDefault();

            return token;
        }
    }
}