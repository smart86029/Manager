using System.Linq;
using MatchaLatte.Common.Events;
using MatchaLatte.Notification.Events.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MatchaLatte.Notification.Api.Extensions
{
    internal static class IApplicationBuilderExtensions
    {
        internal static IApplicationBuilder UseEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            var genericType = typeof(IEventHandler<>);
            var eventHandlerTypes = typeof(UserCreatedEventHandler).Assembly
                .GetTypes()
                .Where(t => t.IsClass && t.IsPublic && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericType))
                .ToList();

            foreach (var eventHandlerType in eventHandlerTypes)
            {
                var interfaces = eventHandlerType.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericType).ToList();
                foreach (var @interface in interfaces)
                {
                    eventBus.Subscribe(@interface.GetGenericArguments()[0], @interface);
                }
            }

            return app;
        }
    }
}