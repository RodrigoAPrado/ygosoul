using System.Runtime.InteropServices;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Native;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Struct;
using YgoSoul.RapTech.Lib.YgoEdo.Factory;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Handler.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Query;

namespace YgoSoul.RapTech.Lib.YgoEdo.Manager;

public class OldDuelRunner
{
    private static OCG_Delegates.DataReader _dataReader;
    private static OCG_Delegates.ScriptReader _scriptReader;
    private static OCG_Delegates.LogHandler _logHandler;
    private static OCG_Delegates.DataReaderDone _readerDone;

    private static List<IdleCmdChoiceCard> _playerChoices;
    
    private static Dictionary<OCG_GameMessage, IParser> _parsers;
    
    public static void RunDuel()
    {
        
        // 1. Verifique a versão (Bom para testar se a DLL carregou)
        OCG_Api.Info.OCG_GetVersion(out int major, out int minor);
        Console.WriteLine($"OCGCore Version: {major}.{minor}");

        // Inicializa banco de dados
        CardDatabase.Init("cards.cdb");
        CardDatabase.LoadCards();
        
        // 2. Configure os delegates (Importante: manter referências static)
        _dataReader = MyCardReader;

        _scriptReader = LoadScript;

        _logHandler = OnLogReceived;
        _readerDone = OnReaderDone;

        // 3. Monte as opções
        var options = new OCG_DuelOptions
        {
            seed0 = 0x12345,
            flags = (ulong)OCG_DuelFlags.MasterRule5,
            team1 = new OCG_Player { startingLP = 8000, startingDrawCount = 5, drawCountPerTurn = 1 },
            team2 = new OCG_Player { startingLP = 8000, startingDrawCount = 5, drawCountPerTurn = 1 },
            cardReader = Marshal.GetFunctionPointerForDelegate(_dataReader),
            scriptReader = Marshal.GetFunctionPointerForDelegate(_scriptReader),
            logHandler = Marshal.GetFunctionPointerForDelegate(_logHandler),
            cardReaderDone = Marshal.GetFunctionPointerForDelegate(_readerDone),
            enableUnsafeLibraries = 0
        };

        _parsers = MessageParserFactory.CreateParsers();

        // 4. Criação do Duelo
        IntPtr pDuel;
        if (OCG_Api.Setup.OCG_CreateDuel(out pDuel, ref options) == 0)
        {
            LoadBaseScripts(pDuel);
            CreateDecks(pDuel);
            RodarDuelo(pDuel);
            OCG_Api.Setup.OCG_DestroyDuel(pDuel);
        }
    }

    private static void LoadBaseScripts(IntPtr pDuel)
    {
        LoadScript(IntPtr.Zero, pDuel, "constant.lua");
        LoadScript(IntPtr.Zero, pDuel, "utility.lua");
        LoadScript(IntPtr.Zero, pDuel, "rankup_functions.lua");
    }

    private static int LoadScript(IntPtr payload, IntPtr pDuel, string name)
    {
        string normalizedName = name.Replace("\\", "/");

        if (!normalizedName.StartsWith("script/"))
            normalizedName = "script/" + normalizedName;

        string fileName = Path.GetFileName(normalizedName);
        string path = Path.Combine("scripts", fileName);

        if (!File.Exists(path))
        {
            Console.WriteLine($"[ERROR] Script not found: {normalizedName}");
            return 0;
        }

        byte[] content = File.ReadAllBytes(path);

        Console.WriteLine($"[LOAD] {normalizedName}");

        return OCG_Api.Setup.OCG_LoadScript(
            pDuel,
            content,
            (uint)content.Length,
            normalizedName
        );
    }
    
    private static void MyCardReader(IntPtr payload, uint code, IntPtr data)
    {
        var cardInfo = CardDatabase.GetCardData(code); // Seu método que busca no SQLite
        Marshal.StructureToPtr(cardInfo, data, false);
    }
    
    // Método que será chamado pela DLL
    private static void OnLogReceived(IntPtr payload, string message, int type)
    {
        // O tipo geralmente indica se é erro (2), aviso (1) ou info (0)
        Console.WriteLine($"[OCGCORE TYPE {type}]: {message}");
    }

    private static void OnReaderDone(IntPtr payload, IntPtr data)
    {
        
    }
    
    private static void ProcessMessages(byte[] buffer)
    {
        int offset = 0;
        
        while (offset < buffer.Length) {
            // 1. Lê o tamanho da mensagem ATUAL (4 bytes)
            int msgSize = BitConverter.ToInt32(buffer, offset);
            offset += 4;

            // 2. Extrai os bytes dessa mensagem específica
            byte[] msgData = new byte[msgSize];
            Array.Copy(buffer, offset, msgData, 0, msgSize);
            offset += msgSize;

            // 3. Processa o ID que está no msgData[0]
            ProcessarUnicaMensagem(msgData);
        }
    }

    private static MessageHandleEnum ProcessarUnicaMensagem(byte[] buffer)
    {
        // 2. O 'msgType' está no byte 4 (logo após o header de tamanho)
        var msgType = (OCG_GameMessage)buffer[0];

        if (_parsers.TryGetValue(msgType, out var value))
        {
            return MessageHandler.HandleMessage(value.SafeParse(buffer));
        }
        
        return MessageHandler.HandleMessage(_parsers[OCG_GameMessage.Unknown].SafeParse(buffer));
    }
    
    private static void CreateDecks(IntPtr pDuel)
    {
        CreateDeck(pDuel, 0, -1, false);
        CreateDeck(pDuel, 1, -1, false);
        
        // 0x01 é LOCATION_DECK
        var quantidadeNoDeck0 = OCG_Api.Query.OCG_DuelQueryCount(pDuel, 0, 0x01);
        Console.WriteLine($"Player 0 MAINDECK Size: {quantidadeNoDeck0}");
        var quantidadeNoDeck1 = OCG_Api.Query.OCG_DuelQueryCount(pDuel, 1, 0x01);
        Console.WriteLine($"Player 1 MAINDECK Size: {quantidadeNoDeck1}");
    }

    private static void CreateDeck(IntPtr pDuel, byte team, int d, bool randomize)
    {
        var deck = DummyDeck.CreateDeck(team, d, randomize);
        foreach (var card in deck)
        {
            var ocgNewCardInfo = card;
            OCG_Api.Setup.OCG_DuelNewCard(pDuel, ref ocgNewCardInfo);
        }
    }
    
    static void RodarDuelo(IntPtr pDuel)
    {
        OCG_Api.Setup.OCG_StartDuel(pDuel);
        Console.WriteLine("--- DUEL STARTED ---");

        bool duelando = true;
        int currentDuelist = 0;

        while (duelando)
        {
            var status = (OCG_DuelStatus) OCG_Api.Run.OCG_DuelProcess(pDuel);
            uint length;
            IntPtr messagePtr = OCG_Api.Run.OCG_DuelGetMessage(pDuel, out length);
            if (length > 0)
            {
                // 1. Criamos um array de bytes no C# com o tamanho que a DLL nos deu
                byte[] dadosLocais = new byte[length];
                // 2. Copiamos o que está naquele endereço 0x25d1... para o nosso array
                Marshal.Copy(messagePtr, dadosLocais, 0, (int)length);
                // 3. Agora sim, olhe para os bytes:
                ProcessMessages(dadosLocais);

                if (status == OCG_DuelStatus.OcgDuelStatusAwating)
                {
                    if (MessageHandler.MessageRequiringInput != null)
                    {
                        duelando = HandlePlayerInput(pDuel);
                    }
                    else
                    {
                        Console.WriteLine("--- SOMETHING WENT WRONG ---");
                        duelando = false;
                    }
                }
                else if (status == OCG_DuelStatus.OcgDuelStatusEnd)
                {
                    Console.WriteLine("--- DUEL ENDED ---");
                    duelando = false;
                }
            }
        }
    }

    private static bool HandlePlayerInput(IntPtr pDuel)
    {
        if(MessageHandler.MessageRequiringInput == null)
            throw new InvalidOperationException("MessageHandler.MessageRequiringInput == null");
        
        
        if (MessageHandler.MessageRequiringInput 
            is SelectBattleCmdMessage
            or SelectIdleCmdMessage
            or DamageMessage
            or RecoverMessage
            or ChainSolvedMessage)
        {
            QueryField(pDuel);
        }
        
        
        switch (MessageHandler.MessageRequiringInput.Input)
        {
            case InputType.Win:
                Console.WriteLine("--- DUEL WIN! ---");
                return false;
            case InputType.Value:
                HandlePlayerInputValue(pDuel);
                break;
            case InputType.Confirmation:
                HandlePlayerInputConfirmation(pDuel);
                break;
            case InputType.Selections:
                HandlePlayerInputSelections(pDuel);
                break;
            case InputType.Sort:
                HandlePlayerInputSort(pDuel);
                break;
            case InputType.SelectChain:
                HandlePlayerSelectChain(pDuel);
                break;
            case InputType.AnnounceCard:
                HandleAnnounceCard(pDuel);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return true;
    }

    private static void HandlePlayerInputValue(IntPtr pDuel)
    {
        var message = MessageHandler.MessageRequiringInput;
        byte[] response = [];
        do
        {
            Console.WriteLine("\n--- AWAITING PLAYER'S INPUT ---");
            Console.Write("Input your selected action: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var choice))
            {
                response = message.GetResponse(new List<int>(choice));
                if (response.Length == 0)
                    Console.WriteLine("--- INVALID CHOICE ---");
            }
            else
            {
                Console.WriteLine("--- INVALID CHOICE ---");
            }
        } while (response.Length == 0);

        OCG_Api.Run.OCG_DuelSetResponse(pDuel, response, (uint) response.Length); 
    }

    private static void HandlePlayerInputConfirmation(IntPtr pDuel)
    {
        Console.WriteLine("\n--- AWAITING PLAYER'S INPUT ---");
        Console.Write("Press enter to confirm... ");
        var input = Console.ReadLine();
    }

    private static void HandleAnnounceCard(IntPtr pDuel)
    {
        var message = (AnnounceCardMessage)MessageHandler.MessageRequiringInput;
        byte[] response = [];
        do
        {
            Console.WriteLine("\n--- AWAITING PLAYER'S INPUT ---");
            Console.Write("Press input a value... ");
            var input = Console.ReadLine();

            if (input == null)
            {
                Console.WriteLine("--- INVALID CHOICE ---");
                continue;
            }
            
            if (int.TryParse(input, out var choice))
            {
                response = message.GetResponse(new List<int>(choice));
                if (response.Length == 0)
                    Console.WriteLine("--- INVALID CHOICE ---");
            }
            else
            {
                var query = message.Query(input);
                if (query.Count == 0)
                {
                    Console.WriteLine("--- NO CARD MATCHING QUERY ---");
                    Console.ReadLine();
                    Console.WriteLine(message.ToString());
                    continue;
                }
                
                Console.WriteLine("The following cards matches your query: ");
                foreach (var q in query)
                {
                    Console.WriteLine($"[{q.Item1}] => {q.Item2}");
                }
            }
        } while (response.Length == 0);
        OCG_Api.Run.OCG_DuelSetResponse(pDuel, response, (uint) response.Length); 
    }

    private static void HandlePlayerSelectChain(IntPtr pDuel)
    {
        var message = (SelectChainMessage)MessageHandler.MessageRequiringInput;
        byte[] response = [];
        do
        {
            Console.WriteLine("\n--- AWAITING PLAYER'S INPUT ---");
            Console.Write("Input your selected action, or just press enter to skip: ");
            var input = Console.ReadLine();
            
            if (input == "")
            {
                Console.WriteLine("\nSkipping chain... ");
                return;
            }
            if (int.TryParse(input, out var choice))
            {
                response = message.GetResponse(new List<int>(choice));
                if (response.Length == 0)
                    Console.WriteLine("--- INVALID CHOICE ---");
            }
            else
            {
                Console.WriteLine("--- INVALID CHOICE ---");
            }
        } while (response.Length == 0);

        OCG_Api.Run.OCG_DuelSetResponse(pDuel, response, (uint) response.Length); 
    }

    private static void HandlePlayerInputSort(IntPtr pDuel)
    {
        var message = (ISelectionOcgMessage)MessageHandler.MessageRequiringInput;
        byte[] response = [];
        do
        {
            Console.WriteLine("\n--- AWAITING PLAYER'S INPUT ---");
            Console.Write("Input your selected action: ");
            var input = Console.ReadLine();
            
            if (input == null)
            {
                Console.WriteLine("--- INVALID CHOICE ---");
                continue;
            }

            if (input.ToLower() == "cancel" && message.CanCancel)
            {
                response = message.Cancel();
                continue;
            }

            var a = input.Split(",");
            var ints = new List<int>();
            var invalid = false;

            for(var i = 0; i < ints.Count; i++)
            {
                if (int.TryParse(a[i], out var j))
                {
                    ints.Add(j);
                }
                else
                {
                    Console.WriteLine("--- INVALID CHOICE ---");
                    invalid = true;
                }
            }

            response = message.GetResponse(ints);
            if (response.Length != 0 && !invalid) 
                continue;
            Console.WriteLine("--- INVALID CHOICE ---");
        } while (response.Length == 0);

        OCG_Api.Run.OCG_DuelSetResponse(pDuel, response, (uint) response.Length); 
    }

    private static void HandlePlayerInputSelections(IntPtr pDuel)
    {
        var responseIds = new List<int>();
        var enter = false;
        var message = (ISelectionOcgMessage)MessageHandler.MessageRequiringInput;
        byte[] response = [];
        do
        {
            Console.WriteLine("\n--- AWAITING PLAYER'S INPUT ---");
            Console.WriteLine("Input your selections. Enter=confirm all, Cancel=cancel operation if able, Clear=reset your inputs: ");
            var value = "";
            foreach (var id in responseIds)
            {
                value += id + ",";
            }
            Console.WriteLine($"Current inputs={value}");
            var input = Console.ReadLine();

            if (input == null)
            {
                Console.WriteLine("--- INVALID CHOICE ---");
                continue;
            }
            
            if (input.ToLower() == "enter")
            {
                response = message.GetResponse(responseIds);
                if (response.Length == 0)
                {
                    Console.WriteLine("--- INVALID CHOICES, REDOING ---");
                    responseIds = [];
                    Console.WriteLine(message.ToString());
                    continue;
                }
                enter = true;
                continue;
            }
            
            if(input.ToLower() == "clear")
            {
                responseIds.Clear();
                continue;
            }

            if (input.ToLower() == "cancel" && message.CanCancel)
            {
                enter = true;
                response = message.Cancel();
                continue;
            }
            
            if (int.TryParse(input, out var choice))
            {
                if (responseIds.Contains(choice))
                {
                    Console.WriteLine("--- OPTION ALREADY CHOSEN ---");
                    continue;
                }
                responseIds.Add(choice);
            }
            else
            {
                Console.WriteLine("--- INVALID CHOICE ---");
            }
        } while (!enter);

        if (response.Length == 0)
        {
            Console.WriteLine("--- INVALID OPTIONS ---");
            HandlePlayerInputSelections(pDuel);
            return;
        }
        OCG_Api.Run.OCG_DuelSetResponse(pDuel, response, (uint) response.Length); 
    }

    private static void QueryField(IntPtr pDuel)
    {
        var query = OCG_Api.Query.OCG_DuelQueryField(pDuel, out var length);
        var data = new byte[length];
        Marshal.Copy(query, data, 0, (int)length);
        Console.WriteLine($"Query Raw: {BitConverter.ToString(data)}");
        var result = QueryParser.ParseField(data);
        Console.WriteLine($"Query: {result}");
    }
}