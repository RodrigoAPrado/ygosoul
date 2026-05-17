using Newtonsoft.Json;

namespace YgoSoul.CardDownloader
{
    public class CardImageCardModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("image_url_small")]
        public string ImageUrlSmall { get; set; }
        [JsonProperty("image_url_cropped")]
        public string ImageUrlCropped { get; set; }
    }
}