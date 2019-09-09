using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchaLatte.HumanResources.App.JobTitles
{
    public interface IJobTitleService
    {
        Task<ICollection<JobTitlSummary>> GetJobTitlsAsync();
    }
}