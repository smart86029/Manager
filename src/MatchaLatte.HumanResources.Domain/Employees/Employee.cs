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
        /// 取得部門 ID。
        /// </summary>
        public Guid DepartmentId => jobChanges.OrderBy(j => j.StartOn).Last().DepartmentId;

        /// <summary>
        /// 取得職稱 ID。
        /// </summary>
        public Guid JobTitleId => jobChanges.OrderBy(j => j.StartOn).Last().JobTitleId;

        /// <summary>
        /// 取得是否在職。
        /// </summary>
        public bool IsEmployed => jobChanges.Any(j => j.StartOn <= DateTime.UtcNow && j.EndOn >= DateTime.UtcNow);

        /// <summary>
        /// 取得職務異動的集合。
        /// </summary>
        public IReadOnlyCollection<JobChange> JobChanges => jobChanges.AsReadOnly();

        public void AssignJob(Department department, JobTitle jobTitle, DateTime startOn)
        {
            jobChanges.Add(new JobChange(Id, department.Id, jobTitle.Id, startOn));
        }
    }
}