using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchaLatte.HumanResources.App.JobTitles
{
    public interface IJobTitleService
    {
        Task<ICollection<JobTitlSummary>> GetJobTitlesAsync();

        Task<JobTitleDetail> GetJobTitleAsync(Guid jobTitleId);

        Task<JobTitleDetail> CreateJobTitleAsync(CreateJobTitleCommand command);

        Task<bool> UpdateJobTitleAsync(UpdateJobTitleCommand command);
    }
}