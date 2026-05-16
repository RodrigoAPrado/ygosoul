using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Base;
using YgoSoul.RapTech.Lib.YgoEdo.Api;

namespace YgoSoul
{
    public static class DuelRunner
    {
        public static void Run()
        {
            var manager = YgoEdo.Init("");

            var result = manager.CreateDuel();

            if (!result)
            {
                Console.WriteLine("Failed to set create duel.");
                return;
            }

            var duel = manager.CurrentDuel;
            result = duel.SetupDuelOptions(
                DuelMode.MasterRule5,
                8000,
                5,
                1,
                8000,
                5,
                1);

            if (!result)
            {
                Console.WriteLine("Failed to set duel options.");
                return;
            }

            result = duel.InitDuel();

            if (!result)
            {
                Console.WriteLine("Failed to init duel.");
                return;
            }

            result = duel.SetDecks(
                DummyDeck.CreateDeck(0, true, false),
                DummyDeck.CreateDeck(0, false, true),
                DummyDeck.CreateDeck(1, true, false),
                DummyDeck.CreateDeck(1, false, true)
            );

            if (!result)
            {
                Console.WriteLine("Failed to set deck.");
                return;
            }

            result = duel.StartDuel();


            if (!result)
            {
                Console.WriteLine("Failed to start duel.");
                return;
            }

            RunningDuel(duel, manager);
        }

        private static void RunningDuel(IDuel duel, IDuelManager manager)
        {
            Console.WriteLine("Starting the duel.");
            var result = true;
            while (duel.State is not DuelState.Destroyed and not DuelState.DuelFinished)
            {
                if (result == false)
                    break;

                if (duel.Messages.Count <= 0)
                {
                    result = duel.ProceedDuel();
                    continue;
                }

                var messageResponse = CheckMessage(duel.Messages[duel.CurrentMessageIndex]);

                if (messageResponse.Count > 0) duel.SetResponse(messageResponse);

                if (!duel.NextMessage())
                    result = duel.ProceedDuel();
            }

            Console.WriteLine("Duel Finished!");
        }

        private static List<int> CheckMessage(IDuelMessage message)
        {
            Console.WriteLine();
            Console.Write(message.ToString());
            switch (message)
            {
                case ISelectChainMessage selectChainMessage:
                    return DoSingleSelection(selectChainMessage);
                case ISelectIdleCommandMessage selectIdleCommandMessage:
                    return DoSingleSelection(selectIdleCommandMessage);
            }

            return new List<int>();
        }

        private static List<int> DoSingleSelection(ISelectionDuelMessage message)
        {
            var result = new List<int>();
            do
            {
                Console.WriteLine("\n--- AWAITING PLAYER'S INPUT ---");
                Console.Write("Input your selected action: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out var choice))
                    result.Add(choice);
                else
                    Console.WriteLine("--- INVALID CHOICE ---");
            } while (result.Count <= 0);

            return result;
        }
    }
}