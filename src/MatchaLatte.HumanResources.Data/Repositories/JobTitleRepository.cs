using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.Domain.JobTitles;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.HumanResources.Data.Repositories
{
    public class JobTitleRepository : IJobTitleRepository
    {
        private readonly HumanResourcesContext context;

        /// <summary>
        /// 初始化 <see cref="JobTitleRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">人力資源內容。</param>
        public JobTitleRepository(HumanResourcesContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<JobTitle>> GetJobTitletsAsync()
        {
            var result = await context
                .Set<JobTitle>()
                .ToListAsync();

            return result;
        }

        public async Task<JobTitle> GetJobTitleAsync(Guid jobTitleId)
        {
            var result = await context
                .Set<JobTitle>()
                .SingleOrDefaultAsync(j => j.Id == jobTitleId);

            return result;
        }

        public void Add(JobTitle jobTitle)
        {
            context.Set<JobTitle>().Add(jobTitle);
        }

        public void Update(JobTitle jobTitle)
        {
            context.Entry(jobTitle).State = EntityState.Modified;
        }
    }
}