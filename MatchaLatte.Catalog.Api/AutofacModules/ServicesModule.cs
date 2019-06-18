using System.Linq;
using Autofac;
using MatchaLatte.Catalog.Services;

namespace MatchaLatte.Catalog.Api.AutofacModules
{
    public class ServicesModule : Module
    {
        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(StoreService).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}