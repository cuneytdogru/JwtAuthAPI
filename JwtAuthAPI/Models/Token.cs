using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthAPI.Models
{
    public class Token
    {
        public static readonly TimeSpan DefaultTokenExpiry = new TimeSpan(1, 0, 0);

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public DateTime Expires { get; set; }

        public bool Disabled { get; private set; }

        public DateTime DisabledDate { get; set; }

        public bool IsExpired
        { get { return DateTime.UtcNow > Expires; } }

        public string Key { get; private set; }

        public Token(User user)
        {
            this.Id = new Guid();
            this.UserId = user.Id;
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.Expires = DateTime.UtcNow.Add(DefaultTokenExpiry);
            this.Key = CreateToken();
        }

        public void Disable()
        {
            this.Disabled = true;
            this.DisabledDate = DateTime.UtcNow;
        }

        private string CreateToken()
        {
            var issuer = AppSettings.Authentication.Issuer;
            var audience = AppSettings.Authentication.Audience;
            var key = Encoding.ASCII.GetBytes(AppSettings.Authentication.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", this.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, this.UserName),
                new Claim(JwtRegisteredClaimNames.Email, this.Email),
                new Claim(JwtRegisteredClaimNames.Jti, this.Id.ToString())
             }),
                Expires = this.Expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}