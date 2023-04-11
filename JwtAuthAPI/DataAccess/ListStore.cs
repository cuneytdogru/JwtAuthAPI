using JwtAuthAPI.Models;

namespace JwtAuthAPI.DataAccess
{
    public static class ListStore
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Token> Tokens { get; set; } = new List<Token>();
    }
}