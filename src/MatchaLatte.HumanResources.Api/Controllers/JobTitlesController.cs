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
        /// 取得所有職稱。
        /// </summary>
        /// <returns>所有職稱。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var jobTitls = await jobTitleService.GetJobTitlsAsync();

            return Ok(jobTitls);
        }
    }
}