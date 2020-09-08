namespace JwtAuthExample.WebAPI.Models
{
    public class AuthenticateResponse
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
