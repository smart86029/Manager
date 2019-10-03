using System;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.HumanResources.App.Departments
{
    public class CreateDepartmentCommand
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public Guid ParentId { get; set; }
    }
}