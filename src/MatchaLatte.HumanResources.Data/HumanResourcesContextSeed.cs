using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.Domain.Departments;
using MatchaLatte.HumanResources.Domain.JobTitles;

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
                    var jobTitles = GetJobTitles();

                    context.Set<Department>().AddRange(departments);
                    context.Set<JobTitle>().AddRange(jobTitles);

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

        private IEnumerable<JobTitle> GetJobTitles()
        {
            var result = new List<JobTitle>();
            result.Add(new JobTitle("總經理", true));
            result.Add(new JobTitle("經理", true));
            result.Add(new JobTitle("高級工程師", true));
            result.Add(new JobTitle("中級工程師", true));

            return result;
        }
    }
}