namespace MatchaLatte.Identity.App.Commands.Tokens
{
    public class RefreshTokenCommand
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}