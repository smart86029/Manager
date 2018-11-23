using System.Threading.Tasks;
using MatchaLatte.Identity.App.Commands.Tokens;
using MatchaLatte.Identity.App.Queries.Tokens;

namespace MatchaLatte.Identity.App.Services
{
    public interface ITokenService
    {
        Task<TokenDetail> CreateTokenAsync(CreateTokenCommand command);
    }
}