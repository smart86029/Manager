using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Queries;
using MatchaLatte.Ordering.App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Ordering.Api.Controllers
{
    /// <summary>
    /// 店家控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly ICommandService commandService;
        private readonly IStoreQueryService storeQueryService;

        /// <summary>
        /// 初始化 <see cref="StoresController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="commandService">命令服務。</param>
        /// <param name="userQueryService">使用者查詢服務。</param>
        public StoresController(ICommandService commandService, IStoreQueryService storeQueryService)
        {
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            this.storeQueryService = storeQueryService ?? throw new ArgumentNullException(nameof(storeQueryService));
        }

        /// <summary>
        /// 取得所有店家。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有店家。</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationOption option)
        {
            var stores = await storeQueryService.GetStoresAsync(option);
            Response.Headers.Add("X-Total-Count", stores.ItemCount.ToString());

            return Ok(stores.Items);
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="id">店家 ID。</param>
        /// <returns>店家。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var store = await storeQueryService.GetStoreAsync(id);
            if (store == null)
                return NotFound();

            return Ok(store);
        }
    }
}