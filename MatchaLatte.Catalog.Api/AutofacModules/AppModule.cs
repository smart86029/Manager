using System.Linq;
using Autofac;
using MatchaLatte.Catalog.App.EventHandlers.Orders;

namespace MatchaLatte.Catalog.Api.AutofacModules
{
    /// <summary>
    /// <see cref="App"/> 模組。
    /// </summary>
    public class AppModule : Module
    {
        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(OrderCreatedEventHandler).Assembly;

            builder
                .RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("EventHandler"))
                .AsImplementedInterfaces();
        }
    }
}