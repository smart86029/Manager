using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Manager.Common;
using Manager.Models;
using Manager.Models.GroupBuying;
using Manager.Services;
using Manager.ViewModels.Stores;
using Microsoft.AspNetCore.Authorization;
//using Manager.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 店家控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    public class StoresController : Controller
    {
        private StoreService storeService;

        /// <summary>
        /// 初始化 <see cref="StoresController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="storeService">店家服務。</param>
        public StoresController(StoreService storeService)
        {
            this.storeService = storeService;
        }

        /// <summary>
        /// 取得所有店家。
        /// </summary>
        /// <returns>所有店家。</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Store>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var stores = await storeService.GetStoresAsync();

            return Ok(stores);
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="id">店家 ID。</param>
        /// <returns>店家。</returns>     
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StoreResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var store = await storeService.GetStoreAsync(id);

            if (store == null)
                return NotFound();

            return Ok(store);
        }

        /// <summary>
        /// 新增店家。
        /// </summary>
        /// <param name="query">新增店家查詢。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Store), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody]CreateStoreQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var store = await storeService.CreateAsync(query);

            return CreatedAtRoute(Constant.RouteName, new { id = store.StoreId }, store);
        }

        /// <summary>
        /// 修改店家。
        /// </summary>
        /// <param name="id">店家ID。</param>
        /// <param name="query">修改店家查詢。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateStoreQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != query.StoreId)
                return BadRequest();

            await storeService.UpdateAsync(query);

            return NoContent();
        }

        /// <summary>
        /// 刪除店家。
        /// </summary>
        /// <param name="id">店家ID。</param>
        /// <returns>204 NoContent。</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await storeService.DeleteAsync(id);

            return NoContent();
        }
    }
}