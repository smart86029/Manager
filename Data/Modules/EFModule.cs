using System;
using System.Data.Entity;
using System.Linq;
using Autofac;
using Manager.Data.EntityFramework;

namespace Manager.Data
{
    /// <summary>
    /// EntityFramework 模組。
    /// </summary>
    public class EFModule : Module
    {
        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<ManagerContext>().As<DbContext>().InstancePerRequest();
        }
    }
}