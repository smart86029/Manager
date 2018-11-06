using System.Linq;
using Autofac;
using MatchaLatte.Ordering.Commands;

namespace MatchaLatte.Ordering.Api.AutofacModules
{
    /// <summary>
    /// <see cref="Commands"/> 模組。
    /// </summary>
    public class CommandsModule : Module
    {
        private string key;
        private string issuer;

        /// <summary>
        /// 初始化 <see cref="CommandsModule"/> 類別的新執行個體。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="issuer"></param>
        public CommandsModule(string key, string issuer)
        {
            this.key = key;
            this.issuer = issuer;
        }

        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandService).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("CommandService"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("CommandHandler"))
                .WithParameter("key", key)
                .WithParameter("issuer", issuer)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}