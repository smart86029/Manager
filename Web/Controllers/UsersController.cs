using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Manager.Data;
using Manager.Models;

namespace Manager.Service.Controllers
{
    /// <summary>
    /// 使用者控制器
    /// </summary>
    public class UsersController : ApiController
    {
        private IUnitOfWork unitOfWork;
        private IUserRepository userRepository;

        /// <summary>
        /// 初始化 <see cref="UsersController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元執行個體。</param>
        /// <param name="userRepository">使用者倉儲執行個體。</param>
        public UsersController(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// 非同步取得所有使用者。
        /// </summary>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含所有使用者。</returns>
        public async Task<IHttpActionResult> Get()
        {
            var users = await userRepository.ManyAsync(null);

            return Ok(users);
        }

        /// <summary>
        /// 非同步取得使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含使用者。</returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            var user = await userRepository.FindAsync(id);

            return Ok(user);
        }

        /// <summary>
        /// 非同步新增使用者。
        /// </summary>
        /// <param name="user">使用者。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 201 Created。</returns>
        public async Task<IHttpActionResult> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            userRepository.Create(user);
            await unitOfWork.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        /// <summary>
        /// 非同步修改使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <param name="user">使用者。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        public async Task<IHttpActionResult> Put(int id, [FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != user.UserId)
                return BadRequest();

            userRepository.Update(user);
            await unitOfWork.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 非同步刪除使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        public async Task<IHttpActionResult> Delete(int id)
        {
            var user = await userRepository.FindAsync(id);
            if (user == null)
                return NotFound();

            userRepository.Delete(user);
            await unitOfWork.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}