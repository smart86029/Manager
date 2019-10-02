using System;
using Newtonsoft.Json;

namespace MatchaLatte.Common.Utilities
{
    /// <summary>
    /// Json 工具。
    /// </summary>
    public static class JsonUtility
    {
        /// <summary>
        /// 序列化。
        /// </summary>
        /// <param name="value">物件。</param>
        /// <returns>字串。</returns>
        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <typeparam name="T">物件類型。</typeparam>
        /// <param name="value">字串。</param>
        /// <returns>物件</returns>
        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <param name="value">字串。</param>
        /// <param name="type">類型。</param>
        /// <returns>物件</returns>
        public static object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }
    }
}