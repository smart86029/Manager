using System;
using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Manager.Services;
using Microsoft.IdentityModel.Tokens;

namespace Manager.Web.Helpers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class JwtAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException(nameof(actionContext));

            if (SkipAuthorization(actionContext))
                return;

            if (!IsAuthorized(actionContext))
                HandleUnauthorizedRequest(actionContext, "驗證錯誤。");
        }

        protected virtual bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException(nameof(actionContext));

            var authorization = actionContext.Request.Headers.Authorization;
            if (authorization == null || authorization.Scheme != "Bearer")
                return false;

            if (string.IsNullOrEmpty(authorization.Parameter))
                return false;

            var requestScope = actionContext.Request.GetDependencyScope();
            var tokenService = requestScope.GetService(typeof(TokenService)) as TokenService;
            var token = authorization.Parameter;
            var principal = tokenService.GetPrincipal(token);

            //var identity = principal.Identity as ClaimsIdentity;

            //if (identity == null)
            //    return false;

            //if (!identity.IsAuthenticated)
            //    return false;

            //var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            //username = usernameClaim?.Value;

            //if (string.IsNullOrEmpty(username))
            //    return false;

            return true;
        }

        protected virtual void HandleUnauthorizedRequest(HttpActionContext actionContext, string message)
        {
            if (actionContext == null)
                throw new ArgumentNullException(nameof(actionContext));

            actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
        }

        /// <summary>
        /// 是否可以省略驗證。
        /// </summary>
        /// <param name="actionContext">包含執行動作的資訊。</param>
        /// <returns>可以省略驗證返回是，否則為否。</returns>
        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any() || 
                actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }


    }
}