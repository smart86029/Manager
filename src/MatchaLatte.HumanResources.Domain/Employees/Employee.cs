using System;
using System.Collections.Generic;
using System.Linq;
using MatchaLatte.HumanResources.Domain.Departments;
using MatchaLatte.HumanResources.Domain.JobTitles;

namespace MatchaLatte.HumanResources.Domain.Employees
{
    /// <summary>
    /// 員工。
    /// </summary>
    public class Employee : Person
    {
        private List<JobChange> jobChanges = new List<JobChange>();

        /// <summary>
        /// 部門 ID。
        /// </summary>
        public Guid DepartmentId { get; }

        public string JobTitle { get; }

        public bool IsEmployed => jobChanges.Any(j => j.StartOn <= DateTime.UtcNow && j.EndOn >= DateTime.UtcNow);

        public IReadOnlyCollection<JobChange> JobChanges => jobChanges;

        public void AssignJob(Department department, JobTitle jobTitle, DateTime startOn)
        {
            jobChanges.Add(new JobChange(Id, department.Id, jobTitle.Id, startOn));
        }
    }
}