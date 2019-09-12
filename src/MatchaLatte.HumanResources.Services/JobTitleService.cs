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

        public async Task<ICollection<JobTitlSummary>> GetJobTitlesAsync()
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

        public async Task<JobTitleDetail> GetJobTitleAsync(Guid jobTitleId)
        {
            var jobTitle = await jobTitleRepository.GetJobTitleAsync(jobTitleId) ?? throw new ArgumentException(nameof(jobTitleId));
            var result = new JobTitleDetail
            {
                Id = jobTitle.Id,
                Name = jobTitle.Name,
                IsEnabled = jobTitle.IsEnabled,
            };

            return result;
        }

        public async Task<JobTitleDetail> CreateJobTitleAsync(CreateJobTitleCommand command)
        {
            var jobTitle = new JobTitle(command.Name, command.IsEnabled);

            jobTitleRepository.Add(jobTitle);
            await unitOfWork.CommitAsync();

            var result = new JobTitleDetail
            {
                Id = jobTitle.Id,
                Name = jobTitle.Name,
                IsEnabled = jobTitle.IsEnabled,
            };

            return result;
        }

        public async Task<bool> UpdateJobTitleAsync(UpdateJobTitleCommand command)
        {
            var jobTitle = await jobTitleRepository.GetJobTitleAsync(command.Id) ?? throw new ArgumentException(nameof(command.Id));

            jobTitle.UpdateName(command.Name);

            if (command.IsEnabled)
                jobTitle.Enable();
            else
                jobTitle.Disable();

            jobTitleRepository.Update(jobTitle);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}