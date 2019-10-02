using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MatchaLatte.HumanResources.Events.Employees;

namespace MatchaLatte.HumanResources.Api.AutofacModules
{
    /// <summary>
    /// <see cref="Events"/> 模組。
    /// </summary>
    public class EventsModule : Module
    {
        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(EmployeeCreatedEventHandler).Assembly;

            builder
                .RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("EventHandler"))
                .AsImplementedInterfaces();
        }
    }
}
