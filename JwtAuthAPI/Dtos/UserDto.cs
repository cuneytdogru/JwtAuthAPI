using JwtAuthAPI.Models;

namespace JwtAuthAPI.Dtos
{
    public class UserDto
    {
        public UserDto(User model)
        {
            this.Id = model.Id;
            this.UserName = model.UserName;
            this.FullName = model.FullName;
            this.Email = model.Email;
            this.Mobile = model.Mobile;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}