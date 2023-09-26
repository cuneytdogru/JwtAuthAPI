using JwtAuthAPI.Models;

namespace JwtAuthAPI.Dtos
{
    public class TokenDto
    {
        public TokenDto(Token model)
        {
            this.Id = model.Id;
            this.UserId = model.UserId;
            this.UserName = model.UserName;
            this.Email = model.Email;
            this.Expires = model.Expires;
            this.Disabled = model.Disabled;
            this.DisabledDate = model.DisabledDate;
            this.Key = model.Key;
        }

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
    }
}