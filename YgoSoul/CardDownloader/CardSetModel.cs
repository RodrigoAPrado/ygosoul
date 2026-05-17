using Newtonsoft.Json;

namespace YgoSoul.CardDownloader
{
    public class CardSetModel
    {
        [JsonProperty("set_name")]
        public string SetName { get; set; }
        [JsonProperty("set_code")]
        public string SetCode { get; set; }
        [JsonProperty("num_of_cards")]
        public int NumberOfCards { get; set; }
        [JsonProperty("tcg_date")]
        public DateTime TcgDate { get; set; }
        [JsonProperty("set_image")]
        public string SetImage { get; set; }
    }
}