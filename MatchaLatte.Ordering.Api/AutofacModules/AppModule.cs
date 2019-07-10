using System.Linq;
using Autofac;
using MatchaLatte.Ordering.App.EventHandlers;

namespace MatchaLatte.Ordering.Api.AutofacModules
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
            var assembly = typeof(UserDisabledEventHandler).Assembly;

            builder
                .RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("EventHandler"))
                .AsImplementedInterfaces();
        }
    }
}