using System;
using RT.Comb;

namespace MatchaLatte.Common.Utilities
{
    /// <summary>
    /// GUID 工具。
    /// </summary>
    public static class GuidUtility
    {
        /// <summary>
        /// 取得新 GUID。
        /// </summary>
        /// <returns>GUID。</returns>
        public static Guid NewGuid()
        {
            return Provider.Sql.Create();
        }
    }
}