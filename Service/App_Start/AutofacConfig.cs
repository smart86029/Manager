using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Manager.Data;

namespace Manager.Service
{
    /// <summary>
    /// Autofac 設定類別。
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new EFModule());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}