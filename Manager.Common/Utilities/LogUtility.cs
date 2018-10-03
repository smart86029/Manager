using System.Threading.Tasks;
using NLog;

namespace Manager.Common.Utilities
{
    /// <summary>
    /// 日誌工具。
    /// </summary>
    public static class LogUtility
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 致命。
        /// </summary>
        /// <param name="message">訊息。</param>
        public static void Fatal(string message)
        {
            Task.Run(() =>
            {
                logger.Fatal(message);
            });
        }

        /// <summary>
        /// 錯誤。
        /// </summary>
        /// <param name="message">訊息。</param>
        public static void Error(string message)
        {
            Task.Run(() =>
            {
                logger.Error(message);
            });
        }

        /// <summary>
        /// 警告。
        /// </summary>
        /// <param name="message">訊息。</param>
        public static void Warn(string message)
        {
            Task.Run(() =>
            {
                logger.Warn(message);
            });
        }

        /// <summary>
        /// 訊息。
        /// </summary>
        /// <param name="message">訊息。</param>
        public static void Info(string message)
        {
            Task.Run(() =>
            {
                logger.Info(message);
            });
        }

        /// <summary>
        /// 除錯。
        /// </summary>
        /// <param name="message">訊息。</param>
        public static void Debug(string message)
        {
            Task.Run(() =>
            {
                logger.Debug(message);
            });
        }

        /// <summary>
        /// 追蹤。
        /// </summary>
        /// <param name="message">訊息。</param>
        public static void Trace(string message)
        {
            Task.Run(() =>
            {
                logger.Trace(message);
            });
        }
    }
}