using System.Text.Json.Serialization;

namespace StreamVault.Models
{
    public class Cast
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("known_for_department")]
        public string Department { get; set; }

        public int Order { get; set; }
    }
}
