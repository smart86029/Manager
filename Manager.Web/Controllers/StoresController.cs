using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Manager.Common;
using Manager.Models;
using Manager.Services;
using Manager.Web.Helpers;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 店家控制器。
    /// </summary>
    [JwtAuthorize]
    public class StoresController : ApiController
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
        /// 非同步取得所有店家。
        /// </summary>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含所有店家。</returns>
        public async Task<IHttpActionResult> Get()
        {
            var stores = await storeService.GetStoresAsync();

            return Ok(stores);
        }

        /// <summary>
        /// 非同步取得店家。
        /// </summary>
        /// <param name="id">店家ID。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含店家。</returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            var store = await storeService.GetStoreAsync(id);

            if (store == null)
                return NotFound();

            return Ok(store);
        }

        /// <summary>
        /// 非同步新增店家。
        /// </summary>
        /// <param name="store">店家。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 201 Created。</returns>
        public async Task<IHttpActionResult> Post([FromBody]Store store)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await storeService.CreateAsync(store);

            return CreatedAtRoute(Constant.RouteName, new { id = store.StoreId }, store);
        }

        /// <summary>
        /// 非同步修改店家。
        /// </summary>
        /// <param name="id">店家ID。</param>
        /// <param name="store">店家。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        public async Task<IHttpActionResult> Put(int id, [FromBody]Store store)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != store.StoreId)
                return BadRequest();

            await storeService.UpdateAsync(store, new string[0]);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 非同步刪除店家。
        /// </summary>
        /// <param name="id">店家ID。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        public async Task<IHttpActionResult> Delete(int id)
        {
            await storeService.DeleteAsync(id);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}