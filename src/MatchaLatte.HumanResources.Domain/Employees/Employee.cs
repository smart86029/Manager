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
        /// <summary>
        /// 初始化 <see cref="Employee"/> 類別的新執行個體。
        /// </summary>
        private Employee() : base()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Employee"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">姓名。</param>
        /// <param name="displayName">顯示名稱。</param>
        /// <param name="birthDate">出生日期。</param>
        /// <param name="gender">性別。</param>
        /// <param name="maritalStatus">婚姻狀況。</param>
        public Employee(string name, string displayName, DateTime birthDate, Gender gender, MaritalStatus maritalStatus) : base(name, displayName, birthDate, gender, maritalStatus)
        {
        }

        private List<JobChange> jobChanges = new List<JobChange>();

        /// <summary>
        /// 取得部門 ID。
        /// </summary>
        public Guid DepartmentId => jobChanges.SingleOrDefault(j => j.StartOn <= DateTime.UtcNow && j.EndOn >= DateTime.UtcNow)?.DepartmentId ?? jobChanges.Last().DepartmentId;

        /// <summary>
        /// 取得職稱 ID。
        /// </summary>
        public Guid JobTitleId => jobChanges.SingleOrDefault(j => j.StartOn <= DateTime.UtcNow && j.EndOn >= DateTime.UtcNow)?.JobTitleId ?? jobChanges.Last().JobTitleId;

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