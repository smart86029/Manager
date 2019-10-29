using System;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.HumanResources.App.Departments
{
    public class UpdateDepartmentCommand : ICommand<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}