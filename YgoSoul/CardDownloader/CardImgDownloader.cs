using System.Net.Http.Json;

namespace YgoSoul.CardDownloader;

public class CardImgDownloader
{
    public static void Download()
    {
        using HttpClient client = new();
        client.BaseAddress = new Uri("https://db.ygoprodeck.com");
        var usuarios = await client.GetFromJsonAsync<List<Usuario>>("/api/v7/cardinfo.php");
    }
}