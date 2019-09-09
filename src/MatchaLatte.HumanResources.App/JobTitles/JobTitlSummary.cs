using System;

namespace MatchaLatte.HumanResources.App.JobTitles
{
    public class JobTitlSummary
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsEnabled { get; set; }
    }
}