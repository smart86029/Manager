using System;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.GroupBuying;
using Manager.App.Queries.GroupBuying;
using Manager.App.ViewModels;
using Manager.App.ViewModels.GroupBuying;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 店家控制器。
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
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
            Response.Headers.Add("X-Pagination", stores.ItemCount.ToString());

            return Ok(stores.Items);
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="id">店家 ID。</param>
        /// <returns>店家。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var store = await storeQueryService.GetStoreAsync(id);
            if (store == null)
                return NotFound();

            return Ok(store);
        }

        /// <summary>
        /// 新增店家。
        /// </summary>
        /// <param name="command">新增店家查詢。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateStoreCommand command)
        {
            var store = await commandService.ExecuteAsync<Store>(command);

            return CreatedAtAction(nameof(Get), new { id = store.StoreId }, store);
        }

        /// <summary>
        /// 修改店家。
        /// </summary>
        /// <param name="id">店家ID。</param>
        /// <param name="command">修改店家命令。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateStoreCommand command)
        {
            if (id != command.StoreId)
                return BadRequest();

            await commandService.ExecuteAsync<bool>(command);

            return NoContent();
        }

        ///// <summary>
        ///// 刪除店家。
        ///// </summary>
        ///// <param name="id">店家ID。</param>
        ///// <returns>204 NoContent。</returns>
        //[HttpDelete("{id}")]
        //[ProducesResponseType((int)HttpStatusCode.NoContent)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await storeService.DeleteAsync(id);

        //    return NoContent();
        //}
    }
}