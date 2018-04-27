using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 團控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private GroupService groupService;

        /// <summary>
        /// 初始化 <see cref="GroupController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="groupService">團服務。</param>
        public GroupController(GroupService groupService)
        {
            this.groupService = groupService;
        }

        /// <summary>
        /// 取得所有團。
        /// </summary>
        /// <returns>所有團。</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var groups = await groupService.GetGroupsAsync();

            return Ok(groups);
        }
    }
}