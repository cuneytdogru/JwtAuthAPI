namespace JwtAuthAPI.Models
{
    public class User
    {
        public User(string userName, string password, string fullName, string email, string mobile)
        {
            Id = Guid.NewGuid();

            UserName = userName;
            Password = password.GetHashCode().ToString();
            FullName = fullName;
            Email = email;
            Mobile = mobile;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}