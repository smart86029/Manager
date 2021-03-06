﻿using System.Linq;
using Autofac;
using MatchaLatte.Notification.Events.Users;

namespace MatchaLatte.Notification.Api.AutofacModules
{
    /// <summary>
    /// <see cref="Events"/> 模組。
    /// </summary>
    public class EventsModule : Module
    {
        /// <summary>
        /// 註冊 Autofac。
        /// </summary>
        /// <param name="builder">可以註冊組件的構建器。</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(UserCreatedEventHandler).Assembly;

            builder
                .RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("EventHandler"))
                .AsImplementedInterfaces();
        }
    }
}