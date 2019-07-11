using MatchaLatte.Common.Events;
using MatchaLatte.Ordering.App.Events;
using MatchaLatte.Ordering.App.Events.Users;
using MatchaLatte.Ordering.Domain.Orders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MatchaLatte.Ordering.Api.Extensions
{
    internal static class IApplicationBuilderExtensions
    {
        internal static IApplicationBuilder UseEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<UserCreated, IEventHandler<UserCreated>>();
            eventBus.Subscribe<UserDisabled, IEventHandler<UserDisabled>>();
            eventBus.Subscribe<OrderCreated, IEventHandler<OrderCreated>>();

            return app;
        }
    }
}