using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Manager.Services;
using Manager.ViewModels;
using Manager.ViewModels.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly PermissionService permissionService;

        /// <summary>
        /// 初始化 <see cref="PermissionsController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="permissionService">權限服務。</param>
        public PermissionsController(PermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <param name="query">分頁查詢。</param>
        /// <returns>所有權限。</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<PermissionViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationQuery query)
        {
            var permissions = await permissionService.GetPermissionsAsync(query);
            Response.Headers.Add("X-Pagination", permissions.ItemCount.ToString());

            return Ok(permissions.Items);
        }
    }
}