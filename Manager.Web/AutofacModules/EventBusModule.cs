using Autofac;
using Manager.Data;
using RabbitMQ.Client;

namespace Manager.Web.AutofacModules
{
    /// <summary>
    /// EventBus 模組。
    /// </summary>
    public class EventBusModule : Module
    {
        private string connectionString;
        private string userName;
        private string password;
        private int retryCount;

        /// <summary>
        /// 初始化 <see cref="EventBusModule"/> 類別的新執行個體。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="issuer"></param>
        public EventBusModule(string connectionString, string userName, string password, int retryCount)
        {
            this.connectionString = connectionString;
            this.userName = userName;
            this.password = password;
            this.retryCount = retryCount;
        }

        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var factory = new ConnectionFactory { HostName = connectionString };

            if (!string.IsNullOrEmpty(userName))
                factory.UserName = userName;

            if (!string.IsNullOrEmpty(password))
                factory.Password = password;

            builder.RegisterType<RabbitMQConnection>()
                .WithParameter("connectionFactory", factory)
                .WithParameter("retryCount", retryCount)
                .AsSelf();

            builder.RegisterType<EventBus>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}