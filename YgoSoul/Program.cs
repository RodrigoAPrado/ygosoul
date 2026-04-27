using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Data.Sqlite;
using YgoSoul;
using YgoSoul.DuelRunner;
using YgoSoul.Factory;
using YgoSoul.Handler;
using YgoSoul.Handler.Enum;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;
using YgoSoul.Parser;
using YgoSoul.Parser.Abstr;

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
                    DuelRunner.RunDuel();
                    break;
                case 1:
                    break;
            }
        }
        Console.WriteLine("Exiting...");
    }

}