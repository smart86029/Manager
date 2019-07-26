using MatchaLatte.Common.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MatchaLatte.HumanResources.Api.Extensions
{
    internal static class IApplicationBuilderExtensions
    {
        internal static IApplicationBuilder UseEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            return app;
        }
    }
}