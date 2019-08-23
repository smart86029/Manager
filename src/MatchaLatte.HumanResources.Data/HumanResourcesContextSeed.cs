using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.Domain.Departments;

namespace MatchaLatte.HumanResources.Data
{
    public class HumanResourcesContextSeed
    {
        private readonly HumanResourcesContext context;

        public HumanResourcesContextSeed(HumanResourcesContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SeedAsync()
        {
            try
            {
                if (!context.Set<Department>().Any())
                {
                    var departments = GetDepartments();

                    context.Set<Department>().AddRange(departments);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        private IEnumerable<Department> GetDepartments()
        {
            var result = new List<Department>();
            var departmentRoot = new Department("總公司", true, null);
            result.Add(departmentRoot);
            result.Add(new Department("管理部", true, departmentRoot.Id));
            result.Add(new Department("會計部", true, departmentRoot.Id));
            result.Add(new Department("研發部", true, departmentRoot.Id));
            result.Add(new Department("資訊部", true, departmentRoot.Id));

            return result;
        }
    }
}