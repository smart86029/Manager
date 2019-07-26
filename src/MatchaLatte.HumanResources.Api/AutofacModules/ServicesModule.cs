using System.Linq;
using Autofac;
using MatchaLatte.HumanResources.Services;

namespace MatchaLatte.HumanResources.Api.AutofacModules
{
    /// <summary>
    /// <see cref="Services"/> 模組。
    /// </summary>
    public class ServicesModule : Module
    {
        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(EmployeeService).Assembly;

            builder
                .RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}