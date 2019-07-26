using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace MatchaLatte.HumanResources.Api.Models
{
    /// <summary>
    /// 當前使用者。
    /// </summary>
    public class CurrentUser
    {
        private IHttpContextAccessor context;

        public CurrentUser(IHttpContextAccessor context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        public Guid UserId => Guid.Parse(context.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sub).Value);

        /// <summary>
        /// 取得使用者名稱。
        /// </summary>
        public string UserName => context.HttpContext.User.FindFirst(JwtRegisteredClaimNames.UniqueName).Value;
    }
}