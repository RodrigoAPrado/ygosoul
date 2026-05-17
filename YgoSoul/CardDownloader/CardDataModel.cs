using Newtonsoft.Json;

namespace YgoSoul.CardDownloader
{
    public class CardDataModel
    {
        [JsonProperty("data")]
        public List<CardModel> Data { get; set; }
    }
}