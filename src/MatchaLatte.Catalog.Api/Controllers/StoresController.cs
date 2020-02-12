using System;
using System.IO;
using System.Threading.Tasks;
using MatchaLatte.Catalog.App.Stores;
using MatchaLatte.Common.Queries;
using MatchaLatte.Common.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace MatchaLatte.Catalog.Api.Controllers
{
    /// <summary>
    /// 店家控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private static readonly string logoFolder = "Pictures";

        private readonly IWebHostEnvironment environment;
        private readonly IStoreService storeService;

        /// <summary>
        /// 初始化 <see cref="StoresController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="environment">裝載環境。</param>
        /// <param name="storeService">店家服務。</param>
        public StoresController(IWebHostEnvironment environment, IStoreService storeService)
        {
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
            this.storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
        }

        /// <summary>
        /// 取得店家的集合。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>店家的集合。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationOption option)
        {
            var stores = await storeService.GetStoresAsync(option);
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
            var store = await storeService.GetStoreAsync(id);
            if (store == null)
                return NotFound();

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
            var fileName = await storeService.GetLogoFileNameAsync(id);
            if (string.IsNullOrWhiteSpace(fileName))
                return NotFound();

            var path = Path.Combine(environment.WebRootPath, logoFolder, fileName);
            var provider = new FileExtensionContentTypeProvider();
            provider.TryGetContentType(fileName, out var contentType);

            return PhysicalFile(path, contentType);
        }

        /// <summary>
        /// 建立店家。
        /// </summary>
        /// <param name="command">建立店家命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateStoreCommand command)
        {
            var store = await storeService.CreateStoreAsync(command);

            return CreatedAtAction("Get", new { id = store.Id }, store);
        }

        /// <summary>
        /// 更新店家。
        /// </summary>
        /// <param name="id">店家 ID。</param>
        /// <param name="store">店家。</param>
        /// <param name="logo">商標。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromForm] string store, IFormFile logo)
        {
            var command = JsonUtility.Deserialize<UpdateStoreCommand>(store);
            if (id != command.Id)
                return BadRequest();

            if (logo?.Length > 0)
            {
                command.LogoFileName = logo.FileName;
                var path = Path.Combine(environment.WebRootPath, logoFolder, logo.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                    await logo.CopyToAsync(stream);
            }

            await storeService.UpdateStoreAsync(command);

            return NoContent();
        }
    }
}