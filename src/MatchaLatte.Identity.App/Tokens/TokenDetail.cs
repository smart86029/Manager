using System.Text.Json.Serialization;

namespace MatchaLatte.Identity.App.Tokens
{
    public class TokenDetail
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("example_parameter")]
        public string ExampleParameter { get; set; }
    }
}