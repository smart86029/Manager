using System;
using System.Net;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.App.Departments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.HumanResources.Api.Controllers
{
    /// <summary>
    /// 部門控制器。
    /// </summary>
    [Authorize]
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

        /// <summary>
        /// 建立部門。
        /// </summary>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateDepartmentCommand command)
        {
            var id = await departmentService.CreateDepartmentAsync(command);

            return CreatedAtAction("Get", new { id }, null);
        }

        /// <summary>
        /// 刪除部門。
        /// </summary>
        /// <returns>204 NoContent。</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await departmentService.DeleteDepartmentAsync(id);

            return NoContent();
        }
    }
}