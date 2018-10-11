using System.Linq;
using Autofac;
using Manager.App.DomainEventHandlers.System;
using Manager.Data;
using Manager.Domain;

namespace Manager.Web.AutofacModules
{
    /// <summary>
    /// 領域事件處理常式模組。
    /// </summary>
    public class DomainEventHandlersModule : Module
    {
        /// <summary>
        /// 初始化 <see cref="DomainEventHandlersModule"/> 類別的新執行個體。
        /// </summary>
        public DomainEventHandlersModule()
        {
        }

        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(UserCreatedDomainEventHandler).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                //.Where(x => x.Name.EndsWith("DomainEventHandler"))
                .AsClosedTypesOf(typeof(IDomainEventHandler<>));

            builder.RegisterType<DomainEventDispatcher>()
                .AsSelf()
                .SingleInstance();
        }
    }
}