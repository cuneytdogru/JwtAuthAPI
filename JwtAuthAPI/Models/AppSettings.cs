namespace JwtAuthAPI.Models
{
    public class AppSettings
    {
        public static Authentication Authentication { get; set; }
    }

    public class Authentication
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}