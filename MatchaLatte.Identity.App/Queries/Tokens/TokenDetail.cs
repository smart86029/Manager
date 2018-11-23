using Newtonsoft.Json;

namespace MatchaLatte.Identity.App.Queries.Tokens
{
    public class TokenDetail
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("example_parameter")]
        public string ExampleParameter { get; set; }
    }
}