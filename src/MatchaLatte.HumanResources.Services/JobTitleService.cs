using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.App.JobTitles;
using MatchaLatte.HumanResources.Domain;
using MatchaLatte.HumanResources.Domain.JobTitles;

namespace MatchaLatte.HumanResources.Services
{
    public class JobTitleService : IJobTitleService
    {
        private readonly IHumanResourcesUnitOfWork unitOfWork;
        private readonly IJobTitleRepository jobTitleRepository;

        public JobTitleService(IHumanResourcesUnitOfWork unitOfWork, IJobTitleRepository jobTitleRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.jobTitleRepository = jobTitleRepository ?? throw new ArgumentNullException(nameof(jobTitleRepository));
        }

        public async Task<ICollection<JobTitlSummary>> GetJobTitlsAsync()
        {
            var jobTitles = await jobTitleRepository.GetJobTitletsAsync();
            var result = jobTitles
                .Select(j => new JobTitlSummary
                {
                    Id = j.Id,
                    Name = j.Name,
                    IsEnabled = j.IsEnabled
                })
                .ToList();

            return result;
        }
    }
}