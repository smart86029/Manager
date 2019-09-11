using System;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.HumanResources.App.JobTitles
{
    public class UpdateJobTitleCommand : ICommand<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsEnabled { get; set; }
    }
}