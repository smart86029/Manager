using MatchaLatte.Common.Commands;
using MatchaLatte.Identity.App.Queries.Tokens;

namespace MatchaLatte.Identity.App.Commands.Tokens
{
    public class CreateTokenCommand : ICommand<TokenDetail>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}