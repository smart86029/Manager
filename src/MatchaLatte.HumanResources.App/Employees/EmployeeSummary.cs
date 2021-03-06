﻿using System;

namespace MatchaLatte.HumanResources.App.Employees
{
    public class EmployeeSummary
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid JobTitleId { get; set; }
    }
}