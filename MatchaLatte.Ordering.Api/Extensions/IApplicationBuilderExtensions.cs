using MatchaLatte.Common.Events;
using MatchaLatte.Ordering.App.Events.Orders;
using MatchaLatte.Ordering.App.Events.Users;
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
            eventBus.Subscribe<OrderStockConfirmed, IEventHandler<OrderStockConfirmed>>();

            return app;
        }
    }
}