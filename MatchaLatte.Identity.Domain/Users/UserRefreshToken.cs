using System;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;

namespace MatchaLatte.Identity.Domain.Users
{
    /// <summary>
    /// 使用者刷新令牌。
    /// </summary>
    public class UserRefreshToken : Entity
    {
        /// <summary>
        /// 初始化 <see cref="UserRefreshToken"/> 類別的新執行個體。
        /// </summary>
        private UserRefreshToken()
        {
        }

        /// <summary>
        /// 初始化 <see cref="UserRefreshToken"/> 類別的新執行個體。
        /// </summary>
        /// <param name="expireOn">到期時間。</param>
        /// <param name="userId">使用者 ID。</param>
        internal UserRefreshToken(DateTime expireOn, Guid userId)
        {
            if (expireOn < DateTime.UtcNow)
                throw new DomainException("到期時間需大於現在時間");

            ExpireOn = expireOn;
            UserId = userId;
        }

        /// <summary>
        /// 取得刷新令牌。
        /// </summary>
        public string RefreshToken { get; private set; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

        /// <summary>
        /// 取得到期時間。
        /// </summary>
        public DateTime ExpireOn { get; private set; }

        /// <summary>
        /// 取得使用者 ID。
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 取得是否到期。
        /// </summary>
        public bool IsExpired => DateTime.UtcNow > ExpireOn;
    }
}