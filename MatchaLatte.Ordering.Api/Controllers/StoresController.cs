using System;
using System.IO;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Commands.Stores;
using MatchaLatte.Ordering.App.Queries;
using MatchaLatte.Ordering.App.Services;
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
        /// <param name="storeQueryService">店家查詢服務。</param>
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
        public async Task<IActionResult> GetAsync([FromQuery] PaginationOption option)
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
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var store = await storeQueryService.GetStoreAsync(id);
            if (store == null)
                return NotFound();

            return Ok(store);
        }

        /// <summary>
        /// 取得新店家。
        /// </summary>
        /// <returns>新店家。</returns>
        [HttpGet("new")]
        public async Task<IActionResult> GetNewAsync()
        {
            var store = await storeQueryService.GetNewStoreAsync();

            return Ok(store);
        }

        /// <summary>
        /// 取得商標。
        /// </summary>
        /// <param name="id">店家 ID。</param>
        /// <returns>商標。</returns>
        [AllowAnonymous]
        [HttpGet("{id}/logo")]      
        public async Task<IActionResult> GetLogoAsync(Guid id)
        {
            var fileName = await storeQueryService.GetLogoFileNameAsync(id);
            if (string.IsNullOrWhiteSpace(fileName))
                return NotFound();

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", fileName);

            return PhysicalFile(path, "image/png");
        }

        /// <summary>
        /// 新增店家。
        /// </summary>
        /// <param name="command">新增店家查詢。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateStoreCommand command)
        {
            var store = await commandService.ExecuteAsync(command);

            return CreatedAtAction(nameof(GetAsync), new { id = store.StoreId }, store);
        }

        /// <summary>
        /// 修改店家。
        /// </summary>
        /// <param name="id">店家ID。</param>
        /// <param name="command">修改店家命令。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateStoreCommand command)
        {
            if (id != command.StoreId)
                return BadRequest();

            await commandService.ExecuteAsync(command);

            return NoContent();
        }
    }
}