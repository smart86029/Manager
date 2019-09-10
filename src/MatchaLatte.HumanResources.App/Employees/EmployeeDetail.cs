using System;
using MatchaLatte.HumanResources.Domain;

namespace MatchaLatte.HumanResources.App.Employees
{
    public class EmployeeDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public string DepartmentName { get; set; }

        public string JobTitleName { get; set; }
    }
}