using System;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.App.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.HumanResources.Api.Controllers
{
    /// <summary>
    /// 員工控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        /// <summary>
        /// 取得所有員工。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有員工。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] EmployeeOption option)
        {
            var employees = await employeeService.GetEmployeesAsync(option);
            Response.Headers.Add("X-Total-Count", employees.ItemCount.ToString());

            return Ok(employees.Items);
        }

        /// <summary>
        /// 取得員工。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>員工。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var employee = await employeeService.GetEmployeeAsync(id);

            return Ok(employee);
        }

        /// <summary>
        /// 新增員工。
        /// </summary>
        /// <param name="command">新增員工命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateEmployeeCommand command)
        {
            var employee = await employeeService.CreateEmployeeAsync(command);

            return CreatedAtAction(nameof(GetAsync), new { id = employee.Id }, employee);
        }
    }
}