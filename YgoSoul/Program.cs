using YgoSoul.CardDownloader;
using YgoSoul.RapTech.Lib.YgoEdo.Domain;

namespace YgoSoul;

class Program
{
        
        
    // Dentro do seu Main ou classe de teste
    static void Main(string[] args)
    {
        Console.WriteLine("Input your choice:");
        Console.WriteLine($"[0] => RunDuel");
        Console.WriteLine($"[1] => DownloadImages");
        Console.WriteLine($"Other => Exit");
        var input = Console.ReadLine();
        if (int.TryParse(input, out var choice))
        {
            switch (choice)
            {
                case 0:
                    DuelRunner.Run();
                    break;
            }
        }
        Console.WriteLine("Exiting...");
    }

}