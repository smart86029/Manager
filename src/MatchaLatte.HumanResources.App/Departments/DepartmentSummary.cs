using System;

namespace MatchaLatte.HumanResources.App.Departments
{
    public class DepartmentSummary
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}