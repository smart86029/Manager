using System;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.HumanResources.Domain.Employees
{
    /// <summary>
    /// 職務異動。
    /// </summary>
    public class JobChange : Entity
    {
        private JobChange()
        {

        }

        public JobChange(Guid employeeId, Guid departmentId, Guid jobTitleId, DateTime startOn)
        {
            EmployeeId = employeeId;
            DepartmentId = departmentId;
            JobTitleId = jobTitleId;
            StartOn = startOn;
        }

        /// <summary>
        /// 取得員工 ID。
        /// </summary>
        public Guid EmployeeId { get; private set; }

        /// <summary>
        /// 取得部門 ID。
        /// </summary>
        public Guid DepartmentId { get; private set; }

        /// <summary>
        /// 取得職稱 ID。
        /// </summary>
        public Guid JobTitleId { get; private set; }

        /// <summary>
        /// 取得開始時間。
        /// </summary>
        public DateTime StartOn { get; private set; }

        /// <summary>
        /// 取得結束時間。
        /// </summary>
        public DateTime? EndOn { get; private set; }
    }
}