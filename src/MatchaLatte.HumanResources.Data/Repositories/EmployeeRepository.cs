using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.HumanResources.Data.Repositories
{
    /// <summary>
    /// 員工存放庫。
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HumanResourcesContext context;

        /// <summary>
        /// 初始化 <see cref="EmployeeRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">人力資源內容。</param>
        public EmployeeRepository(HumanResourcesContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<Employee>> GetEmployeesAsync(int offset, int limit)
        {
            var result = await context
                .Set<Employee>()
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return result;
        }

        public Task<int> GetEmployeesCountAsync()
        {
            return context.Set<Employee>().CountAsync();
        }
    }
}
