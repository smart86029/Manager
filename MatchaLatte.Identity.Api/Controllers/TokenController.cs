using System.Threading.Tasks;
using MatchaLatte.Identity.App.Commands.Tokens;
using MatchaLatte.Identity.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Identity.Api.Controllers
{
    /// <summary>
    /// 令牌控制器。
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        /// <summary>
        /// 初始化 <see cref="TokenController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="tokenService">令牌服務。</param>
        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        /// <summary>
        /// 新增令牌。
        /// </summary>
        /// <param name="command">新增令牌命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> PostAsync([FromBody] CreateTokenCommand command)
        {
            var token = await tokenService.CreateTokenAsync(command);
            if (token == null)
                return BadRequest();

            return Ok(token);
        }
    }
}