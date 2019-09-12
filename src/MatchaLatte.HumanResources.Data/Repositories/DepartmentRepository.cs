using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.Domain.Departments;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.HumanResources.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HumanResourcesContext context;

        /// <summary>
        /// 初始化 <see cref="DepartmentRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">人力資源內容。</param>
        public DepartmentRepository(HumanResourcesContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<Department>> GetDepartmentsAsync()
        {
            var result = await context
                .Set<Department>()
                .ToListAsync();

            return result;
        }

        public async Task<Department> GetDepartmentAsync(Guid departmentId)
        {
            var result = await context
                .Set<Department>()
                .SingleOrDefaultAsync(d => d.Id == departmentId);

            return result;
        }

        public void Add(Department department)
        {
            context.Set<Department>().Add(department);
        }

        public void Update(Department department)
        {
            context.Set<Department>().Update(department);
        }
    }
}