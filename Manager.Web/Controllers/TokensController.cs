using System.Threading.Tasks;
using System.Web.Http;
using Manager.Common;
using Manager.Services;
using Manager.ViewModels;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 令牌控制器。
    /// </summary>
    public class TokensController : ApiController
    {
        private TokenService tokenService;

        /// <summary>
        /// 初始化 <see cref="TokensController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userService">使用者服務。</param>
        public TokensController(TokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        /// <summary>
        /// 非同步新增令牌。
        /// </summary>
        /// <param name="query">新增令牌查詢。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 201 Created。</returns>
        public async Task<IHttpActionResult> Post([FromBody]CreateTokenQuery query)
        {
            var token = await tokenService.CreateTokenAsync(query);
            if (string.IsNullOrWhiteSpace(token))
                return Unauthorized();

            return CreatedAtRoute(Constant.RouteName, new { id = 1 }, token);
        }
    }
}