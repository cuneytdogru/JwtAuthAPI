namespace JwtAuthAPI.Dtos
{
    public class LoginResponseDto
    {
        public LoginResponseDto(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}