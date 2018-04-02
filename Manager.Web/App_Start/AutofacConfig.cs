﻿using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Manager.Data;
using Manager.Services;

namespace Manager.Web
{
    /// <summary>
    /// Autofac 組態。
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 註冊。
        /// </summary>
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}