using System;
using MatchaLatte.Common.Commands;
using MatchaLatte.HumanResources.Domain;

namespace MatchaLatte.HumanResources.App.Employees
{
    public class CreateEmployeeCommand : ICommand<EmployeeDetail>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public MaritalStatus MaritalStatus { get; set; }
    }
}