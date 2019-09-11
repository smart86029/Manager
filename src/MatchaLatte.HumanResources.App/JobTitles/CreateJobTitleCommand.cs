using MatchaLatte.Common.Commands;

namespace MatchaLatte.HumanResources.App.JobTitles
{
    public class CreateJobTitleCommand : ICommand<JobTitleDetail>
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }
    }
}