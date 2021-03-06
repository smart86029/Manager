﻿using System;

namespace MatchaLatte.Common.Exceptions
{
    /// <summary>
    /// 非法例外。
    /// </summary>
    public class InvalidException : Exception
    {
        /// <summary>
        /// 初始化 <see cref="InvalidException"/> 類別的新執行個體。
        /// </summary>
        /// <param name="message">訊息。</param>
        public InvalidException(string message) : base(message)
        {
        }
    }
}