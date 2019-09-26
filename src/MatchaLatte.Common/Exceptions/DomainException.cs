using System;

namespace MatchaLatte.Common.Exceptions
{
    /// <summary>
    /// 領域例外。
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        /// 初始化 <see cref="DomainException"/> 類別的新執行個體。
        /// </summary>
        /// <param name="message">訊息。</param>
        public DomainException(string message) : base(message)
        {
        }
    }
}