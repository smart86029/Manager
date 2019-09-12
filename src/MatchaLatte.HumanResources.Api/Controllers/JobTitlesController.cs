using System;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.App.JobTitles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.HumanResources.Api.Controllers
{
    /// <summary>
    /// 職稱控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitlesController : ControllerBase
    {
        private readonly IJobTitleService jobTitleService;

        /// <summary>
        /// 初始化 <see cref="JobTitlesController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="jobTitleService">職稱服務。</param>
        public JobTitlesController(IJobTitleService jobTitleService)
        {
            this.jobTitleService = jobTitleService ?? throw new ArgumentNullException(nameof(jobTitleService));
        }

        /// <summary>
        /// 取得職稱的集合。
        /// </summary>
        /// <returns>職稱的集合。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var jobTitles = await jobTitleService.GetJobTitlesAsync();

            return Ok(jobTitles);
        }

        /// <summary>
        /// 取得職稱。
        /// </summary>
        /// <returns>職稱。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var jobTitle = await jobTitleService.GetJobTitleAsync(id);

            return Ok(jobTitle);
        }

        /// <summary>
        /// 建立職稱。
        /// </summary>
        /// <param name="command">建立職稱命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateJobTitleCommand command)
        {
            var jobTitle = await jobTitleService.CreateJobTitleAsync(command);

            return CreatedAtAction(nameof(GetAsync), new { id = jobTitle.Id }, jobTitle);
        }

        /// <summary>
        /// 更新職稱。
        /// </summary>
        /// <param name="id">職稱 ID。</param>
        /// <param name="command">更新職稱命令。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateJobTitleCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await jobTitleService.UpdateJobTitleAsync(command);

            return NoContent();
        }
    }
}