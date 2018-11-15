using System.Threading.Tasks;
using MatchaLatte.Identity.App.ViewModels.Token;

namespace MatchaLatte.Identity.App.Services
{
    public interface ITokenService
    {
        Task<Token> CreateTokenAsync(CreateTokenOption option);
    }
}