using System.Linq;
using Autofac;
using MatchaLatte.Catalog.Data;

namespace MatchaLatte.Catalog.Api.AutofacModules
{
    /// <summary>
    /// <see cref="Data"/> 模組。
    /// </summary>
    public class DataModule : Module
    {
        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CatalogContext).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Context"))
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("UnitOfWork"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}