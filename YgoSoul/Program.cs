using YgoSoul.CardDownloader;

namespace YgoSoul
{
    internal class Program
    {
        // Dentro do seu Main ou classe de teste
        private static void Main(string[] args)
        {
            Console.WriteLine("Input your choice:");
            Console.WriteLine("[0] => RunDuel");
            Console.WriteLine("[1] => DownloadImages");
            Console.WriteLine("Other => Exit");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var choice))
                switch (choice)
                {
                    case 0:
                        OldDuelRunner.RunDuel();
                        break;
                    case 1:
                        WaitTask();
                        break;
                }

            Console.WriteLine("Exiting...");
        }

        private static void WaitTask()
        {
            var task = Task.Run(CardImgDownloader.Download);
            do
            {
                Thread.Sleep(1000);
            } while (!task.IsCompleted);
        }
    }
}


//0000 = 0
//0001 = 1
//0010 = 2
//0011 = 3
//0100 = 4
//0101 = 5
//0110 = 6
//0111 = 7
//1000 = 8
//1001 = 9