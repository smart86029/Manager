using System.Threading.Tasks;
using Manager.Services;
using Manager.ViewModels.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 令牌控制器。
    /// </summary>
    [Route("api/[controller]")]
    public class TokensController : Controller
    {
        private TokenService tokenService;

        /// <summary>
        /// 初始化 <see cref="TokensController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="tokenService">令牌服務。</param>
        public TokensController(TokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        /// <summary>
        /// 新增令牌。
        /// </summary>
        /// <param name="query">新增令牌查詢。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTokenQuery query)
        {
            var token = await tokenService.CreateTokenAsync(query);
            if (string.IsNullOrWhiteSpace(token))
                return Unauthorized();

            return Created(string.Empty, new { token = token });
        }
    }
}