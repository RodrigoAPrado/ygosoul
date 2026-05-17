using System.Net;
using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Card.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Data.Card;

namespace YgoSoul.CardDownloader
{
    public class CardImgDownloader
    {

        private static List<string> Cards404 = new List<string>();
        
        private static List<Tuple<string, string>> CardDates = new()
        {
            new Tuple<string, string>("2000-01-01", "2001-08-03"),
            new Tuple<string, string>("2001-08-04", "2002-08-03"),
            new Tuple<string, string>("2002-08-04", "2003-08-03"),
            new Tuple<string, string>("2003-08-04", "2004-08-03"),
            new Tuple<string, string>("2004-08-04", "2005-08-03"),
            new Tuple<string, string>("2005-08-04", "2006-08-03"),
            new Tuple<string, string>("2006-08-04", "2007-08-03"),
            new Tuple<string, string>("2007-08-04", "2008-08-03"),
            new Tuple<string, string>("2008-08-04", "2009-08-03"),
            new Tuple<string, string>("2009-08-04", "2010-08-03"),
            new Tuple<string, string>("2010-08-04", "2011-08-03"),
            new Tuple<string, string>("2011-08-04", "2012-08-03"),
            new Tuple<string, string>("2012-08-04", "2013-08-03"),
            new Tuple<string, string>("2013-08-04", "2014-08-03"),
            new Tuple<string, string>("2014-08-04", "2015-08-03"),
            new Tuple<string, string>("2015-08-04", "2016-08-03"),
            new Tuple<string, string>("2016-08-04", "2017-01-03"),
            new Tuple<string, string>("2017-01-04", "2017-05-03"),
            new Tuple<string, string>("2017-05-04", "2017-07-03"),
            new Tuple<string, string>("2017-07-04", "2017-07-23"),//bugado
            new Tuple<string, string>("2017-07-24", "2017-08-03"),
            new Tuple<string, string>("2017-08-04", "2018-08-03"),
            new Tuple<string, string>("2018-08-04", "2019-08-03"),
            new Tuple<string, string>("2019-08-04", "2020-08-03"),
            new Tuple<string, string>("2020-08-04", "2021-08-03"),
            new Tuple<string, string>("2021-08-04", "2022-08-03"),
            new Tuple<string, string>("2022-08-04", "2023-08-03"),
            new Tuple<string, string>("2023-08-04", "2024-08-03"),
            new Tuple<string, string>("2024-08-04", "2025-08-03"),
            new Tuple<string, string>("2025-08-04", "2026-08-04")
        };

        public static async Task Download()
        {
            Console.WriteLine("Which images would you like to download?");
            Console.WriteLine("[0] => Cropped");;
            Console.WriteLine("[1] => Small");
            var result = Console.ReadLine();
            bool small = false;
            if (int.TryParse(result, out int resultInt))
            {
                small = resultInt > 0;
            }
            else
            {
                Console.WriteLine("Invalid input, defaulting to cropped.");
            }
            
            await DownloadCards(small);
            var sb = new StringBuilder();
            sb.Append("SELECT * FROM texts JOIN datas ON texts.id = datas.id WHERE texts.id IN (");
            for (var i = 0; i<Cards404.Count; i++)
            {
                sb.Append($"{Cards404[i]}");
                if(i<Cards404.Count - 1)
                    sb.Append(",");
            }
            sb.Append(")");
            Console.WriteLine(sb.ToString());
        }

        private static async Task DownloadCards(bool small)
        {
            Console.WriteLine("Downloading Cards...");

            var index = 0f;
            foreach (var date in CardDates)
            {
                var percent = index / (CardDates.Count) * 100;
                percent = MathF.Floor(percent * 100f) / 100f;
                Console.WriteLine($"Downloading Jsons for Dates {date}: {percent}%");
                await DownloadJsons(date.Item1, date.Item2, small);
                index++;
            }
        }

        private static async Task DownloadJsons(string startDate, string endDate, bool small)
        {
            using HttpClient client = new();

            try
            {
                var responseBody = await client.GetStringAsync($"https://db.ygoprodeck.com/api/v7/cardinfo.php?startdate={startDate}&enddate={endDate}&dateregion=tcg");
                try
                {
                    var result = JsonConvert.DeserializeObject<CardDataModel>(responseBody);
                    if (result != null)
                    {
                        Dictionary<string, string> imgToDownload;
                        if (small)
                        {
                            imgToDownload= 
                                result.Data.SelectMany(model => model.CardImages)
                                    .ToDictionary(image => $"{image.Id}", image => image.ImageUrlSmall);
                        }
                        else
                        {
                            imgToDownload= 
                                result.Data.SelectMany(model => model.CardImages)
                                    .ToDictionary(image => $"{image.Id}", image => image.ImageUrlCropped);
                        }
                        await DownloadCardImages(imgToDownload, small);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private static async Task DownloadCardImages(Dictionary<string, string> urlDictionary, bool small)
        {
            float index = 0;
            var smallPath = small ? "-small" : "";
            var filePath = $"imgs{smallPath}/";
            
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            
            foreach (var value in urlDictionary)
            {
                var fileName = value.Key + ".jpg";
                var fullPath = Path.Combine(filePath, fileName);
                if (File.Exists(fullPath))
                    continue;
                
                using HttpClient client = new();

                try
                {
                    var responseBody = await client.GetByteArrayAsync(value.Value);
                    await File.WriteAllBytesAsync(fullPath, responseBody);
                    index++;
                    var percent = index / (urlDictionary.Count) * 100;
                    percent = MathF.Floor(percent * 100f) / 100f;
                    Console.WriteLine($"Baixado: {fileName} - Total: {percent}%");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    Console.WriteLine($"FailedCard: {value.Key} - URL: {value.Value}");
                    Cards404.Add(value.Key);
                }
            }
        }
    }
}