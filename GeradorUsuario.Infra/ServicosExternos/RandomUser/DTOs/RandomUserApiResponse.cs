using System.Text.Json.Serialization;

namespace GeradorUsuario.Infra.ServicosExternos.RandomUser.DTOs
{
    public class RandomUserApiResponse
    {
        [JsonPropertyName("results")]
        public List<RandomUser> Results { get; set; }
    }

    public class RandomUser
    {
        [JsonPropertyName("name")]
        public RandomUserName Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("login")]
        public RandomUserLogin Login { get; set; }
    }

    public class RandomUserName
    {
        [JsonPropertyName("first")]
        public string First { get; set; }
        [JsonPropertyName("last")]
        public string Last { get; set; }
    }

    public class RandomUserLogin
    {
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
