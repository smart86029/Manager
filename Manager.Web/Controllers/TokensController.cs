using System;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 令牌控制器。
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TokensController : ControllerBase
    {
        private readonly ICommandService commandService;

        /// <summary>
        /// 初始化 <see cref="TokensController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="commandService">命令服務。</param>
        public TokensController(ICommandService commandService)
        {
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
        }

        /// <summary>
        /// 新增令牌。
        /// </summary>
        /// <param name="command">新增令牌命令。</param>
        /// <returns>令牌。</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTokenCommand command)
        {
            var token = await commandService.ExecuteAsync<string>(command);
            if (string.IsNullOrWhiteSpace(token))
                return Unauthorized();

            return Created(string.Empty, new { token });
        }
    }
}