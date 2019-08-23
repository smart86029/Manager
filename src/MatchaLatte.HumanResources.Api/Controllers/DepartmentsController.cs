using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.HumanResources.Api.Controllers
{
    /// <summary>
    /// 部門控制器。
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
        }

        /// <summary>
        /// 取得所有部門。
        /// </summary>
        /// <returns>所有部門。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var departments = await departmentService.GetDepartmentsAsync();

            return Ok(departments);
        }
    }
}
