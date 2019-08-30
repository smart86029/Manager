using System;

namespace MatchaLatte.HumanResources.App.Employees
{
    public class EmployeeDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string DepartmentName { get; set; }

        public string JobTitleName { get; set; }
    }
}