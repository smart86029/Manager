using System;
using System.Linq;
using Autofac;

namespace Manager.Service
{
    /// <summary>
    /// 服務模組。
    /// </summary>
    public class ServiceModule : Module
    {
        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsSelf()
                   .InstancePerRequest();
        }
    }
}