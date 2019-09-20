using System.Linq;
using Autofac;
using MatchaLatte.Notification.Data.Repositories;
using MongoDB.Driver;

namespace MatchaLatte.Notification.Api.AutofacModules
{
    public class DataModule : Module
    {
        private readonly string connectionString;
        private readonly string databaseName;

        public DataModule(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(MessageRepository).Assembly;

            builder
                .RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var client = new MongoClient(connectionString);
            builder
                .Register(c => client.GetDatabase(databaseName))
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}