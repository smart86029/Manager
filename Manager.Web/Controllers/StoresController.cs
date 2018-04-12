using System.Net;
using System.Threading.Tasks;

using Manager.Common;
using Manager.Models;
using Manager.Models.GroupBuying;
using Manager.Services;
using Manager.ViewModels.Stores;
//using Manager.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 店家控制器。
    /// </summary>
    //[JwtAuthorize]
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
        //[ResponseType(typeof(StoreResult))]
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
        /// <param name="store">店家。</param>
        /// <returns>201 Created。</returns>
        public async Task<IActionResult> Post([FromBody]Store store)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await storeService.CreateAsync(store);

            return CreatedAtRoute(Constant.RouteName, new { id = store.StoreId }, store);
        }

        /// <summary>
        /// 修改店家。
        /// </summary>
        /// <param name="id">店家ID。</param>
        /// <param name="store">店家。</param>
        /// <returns>204 NoContent。</returns>
        public async Task<IActionResult> Put(int id, [FromBody]Store store)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != store.StoreId)
                return BadRequest();

            await storeService.UpdateAsync(store, new string[0]);

            return NoContent();
        }

        /// <summary>
        /// 刪除店家。
        /// </summary>
        /// <param name="id">店家ID。</param>
        /// <returns>204 NoContent。</returns>
        public async Task<IActionResult> Delete(int id)
        {
            await storeService.DeleteAsync(id);

            return NoContent();
        }
    }
}