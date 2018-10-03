using Newtonsoft.Json;

namespace Manager.Common.Utilities
{
    /// <summary>
    /// JSON 工具。
    /// </summary>
    public static class JsonUtility
    {
        /// <summary>
        /// 序列化。
        /// </summary>
        /// <param name="value">物件。</param>
        /// <returns>JSON 字串。</returns>
        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <typeparam name="T">物件型別。</typeparam>
        /// <param name="value">JSON 字串。</param>
        /// <returns>物件。</returns>
        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}