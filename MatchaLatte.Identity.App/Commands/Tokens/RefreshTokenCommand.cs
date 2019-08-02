using Newtonsoft.Json;

namespace MatchaLatte.Identity.App.Commands.Tokens
{
    public class RefreshTokenCommand
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}