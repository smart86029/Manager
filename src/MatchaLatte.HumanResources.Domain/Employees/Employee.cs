using System;
using System.Collections.Generic;

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
        public Guid Department { get; }

        public string JobTitle { get; }

        public bool IsEmployed { get; }

        public IReadOnlyCollection<JobChange> JobChanges => jobChanges;
    }
}