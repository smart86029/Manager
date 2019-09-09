using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Queries;

namespace MatchaLatte.HumanResources.App.Employees
{
    /// <summary>
    /// 員工服務。
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// 取得所有員工。
        /// </summary>
        /// <param name="option">員工選項</param>
        /// <returns>所有員工。</returns>
        Task<PaginationResult<EmployeeSummary>> GetEmployeesAsync(EmployeeOption option);

        /// <summary>
        /// 取得員工。
        /// </summary>
        /// <param name="employeeId">員工 ID。</param>
        /// <returns>員工。</returns>
        Task<EmployeeDetail> GetEmployeeAsync(Guid employeeId);

        /// <summary>
        /// 建立員工。
        /// </summary>
        /// <param name="command">建立員工命令。</param>
        /// <returns>員工。</returns>
        Task<EmployeeDetail> CreateEmployeeAsync(CreateEmployeeCommand command);

        /// <summary>
        /// 更新員工。
        /// </summary>
        /// <param name="command">更新員工命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        Task<bool> UpdateEmployeeAsync(UpdateEmployeeCommand command);
    }
}