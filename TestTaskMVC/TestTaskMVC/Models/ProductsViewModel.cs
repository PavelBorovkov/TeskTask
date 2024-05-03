using System.Text.Json.Serialization;

namespace TestTaskMVC.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("imglink")]
        public string? ImgLink { get; set; }
    }
    public class ProductsViewModel
    {
        public List<Product> Products { get; set;}
    }
}
