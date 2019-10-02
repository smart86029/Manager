using System.Linq;
using Autofac;
using MatchaLatte.Ordering.Services;

namespace MatchaLatte.Ordering.Api.AutofacModules
{
    /// <summary>
    /// <see cref="Services"/> 模組。
    /// </summary>
    public class ServicesModule : Module
    {
        private string connectionString;

        /// <summary>
        /// 初始化 <see cref="ServicesModule"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        public ServicesModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(OrderService).Assembly;

            builder
                .RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .WithParameter("connectionString", connectionString)
                .InstancePerLifetimeScope();
        }
    }
}