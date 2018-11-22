using System.Linq;
using Autofac;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.Commands;

namespace MatchaLatte.Ordering.Api.AutofacModules
{
    /// <summary>
    /// <see cref="Commands"/> 模組。
    /// </summary>
    public class CommandsModule : Module
    {
        /// <summary>
        /// 初始化 <see cref="CommandsModule"/> 類別的新執行個體。
        /// </summary>
        public CommandsModule()
        {
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
                .AsClosedTypesOf(typeof(ICommandHandler<,>));
            builder.RegisterGeneric(typeof(CommandHandlerAdapter<,>))
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}