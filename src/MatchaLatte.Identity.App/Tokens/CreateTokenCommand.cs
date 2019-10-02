using MatchaLatte.Common.Commands;

namespace MatchaLatte.Identity.App.Tokens
{
    public class CreateTokenCommand : ICommand<TokenDetail>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}