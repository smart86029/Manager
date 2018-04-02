using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Manager.Common;

namespace Manager.Web
{
    /// <summary>
    /// Web API 組態。
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 註冊。
        /// </summary>
        /// <param name="config">組態。</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: Constant.RouteName,
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
