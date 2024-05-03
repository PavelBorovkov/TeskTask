using System.Text.Json.Serialization;

namespace TestTaskMVC.Models
{
    public class Coin
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("Value")]
        public int Value { get; set; }

        [JsonPropertyName("access")]
        public bool Access { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
    public class CoinsViewModel
    {
        public List<Coin> Coins { get; set; }
    }
}
