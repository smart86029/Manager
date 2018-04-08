﻿using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Manager.Common;
using Manager.Models;
using Manager.Models.System;
using Manager.Services;
using Manager.ViewModels.Users;
using Manager.Web.Helpers;

namespace Manager.Service.Controllers
{
    /// <summary>
    /// 使用者控制器。
    /// </summary>
    [JwtAuthorize]
    public class UsersController : ApiController
    {
        private UserService userService;

        /// <summary>
        /// 初始化 <see cref="UsersController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userService">使用者服務。</param>
        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 非同步取得所有使用者。
        /// </summary>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含所有使用者。</returns>
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Get()
        {
            var users = await userService.GetUsersAsync();

            return Ok(users);
        }

        /// <summary>
        /// 非同步取得使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含使用者。</returns>
        [ResponseType(typeof(UserResult))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var user = await userService.GetUserIncludeRolesAsync(id);

            return Ok(user);
        }

        /// <summary>
        /// 非同步取得使用者。
        /// </summary>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含使用者。</returns>
        [Route("api/Users/New")]
        [ResponseType(typeof(UserResult))]
        public async Task<IHttpActionResult> GetNew()
        {
            var user = await userService.GetNewUserAsync();

            return Ok(user);
        }

        /// <summary>
        /// 非同步新增使用者。
        /// </summary>
        /// <param name="query">新增使用者查詢。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 201 Created。</returns>
        public async Task<IHttpActionResult> Post([FromBody]CreateUserQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userService.CreateAsync(query);

            return CreatedAtRoute(Constant.RouteName, new { id = user.UserId }, query);
        }

        /// <summary>
        /// 非同步修改使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <param name="query">更新使用者查詢。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        public async Task<IHttpActionResult> Put(int id, [FromBody]UpdateUserQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != query.UserId)
                return BadRequest();

            await userService.UpdateAsync(query);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 非同步刪除使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        public async Task<IHttpActionResult> Delete(int id)
        {
            await userService.DeleteAsync(id);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}