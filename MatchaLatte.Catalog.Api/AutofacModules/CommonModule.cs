using Autofac;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Catalog.Api.AutofacModules
{
    /// <summary>
    /// <see cref="Common"/> 模組。
    /// </summary>
    public class CommonModule : Module
    {
        private string connectionString;

        /// <summary>
        /// 初始化 <see cref="CommonModule"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        public CommonModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventBus>()
                .AsImplementedInterfaces()
                .WithParameter("connectionString", connectionString)
                .SingleInstance();
        }
    }
}