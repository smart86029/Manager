using System;
using System.Security.Cryptography;
using System.Text;

namespace MatchaLatte.Common.Utilities
{
    /// <summary>
    /// 密碼學工具。
    /// </summary>
    public static class CryptographyUtility
    {
        private const string Salt = "8B2085F74DFA9C78A23B7D573C23D27D6D0B0E50C82A9B13138B193325BE3814";

        /// <summary>
        /// 雜湊。
        /// </summary>
        /// <param name="input">輸入值。</param>
        /// <returns>雜湊。</returns>
        public static string Hash(string input)
        {
            var sha256 = SHA256.Create();
            var source = Encoding.UTF8.GetBytes(input + Salt);
            var hash = sha256.ComputeHash(source);
            var result = Convert.ToBase64String(hash);

            return result;
        }
    }
}