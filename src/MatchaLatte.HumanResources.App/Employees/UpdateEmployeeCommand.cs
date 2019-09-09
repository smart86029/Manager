using System;
using MatchaLatte.Common.Commands;
using MatchaLatte.HumanResources.Domain;

namespace MatchaLatte.HumanResources.App.Employees
{
    public class UpdateEmployeeCommand : ICommand<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid JobTitleId { get; set; }

        public DateTime StartOn { get; set; }
    }
}