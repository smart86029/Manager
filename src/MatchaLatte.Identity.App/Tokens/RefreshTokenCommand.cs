using MatchaLatte.Common.Commands;

namespace MatchaLatte.Identity.App.Tokens
{
    public class RefreshTokenCommand : ICommand<TokenDetail>
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}