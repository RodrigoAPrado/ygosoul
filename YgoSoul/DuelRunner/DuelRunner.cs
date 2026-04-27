using System.Runtime.InteropServices;
using YgoSoul.Factory;
using YgoSoul.Handler;
using YgoSoul.Handler.Enum;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.DuelRunner;

public class DuelRunner
{
    private static DataReader _dataReader;
    private static ScriptReader _scriptReader;
    private static LogHandler _logHandler;
    private static DataReaderDone _readerDone;

    private static List<IdleCmdChoiceCard> _playerChoices;
    
    private static Dictionary<GameMessage, IParser> _parsers;
    
    public static void RunDuel()
    {
        
        // 1. Verifique a versão (Bom para testar se a DLL carregou)
        OcgApi.OCG_GetVersion(out int major, out int minor);
        Console.WriteLine($"OCGCore Version: {major}.{minor}");

        // Inicializa banco de dados
        CardDatabase.Initialize("cards.cdb");
        
        // 2. Configure os delegates (Importante: manter referências static)
        _dataReader = MyCardReader;

        _scriptReader = LoadScript;

        _logHandler = OnLogReceived;
        _readerDone = OnReaderDone;

        // 3. Monte as opções
        var options = new OCG_DuelOptions
        {
            seed0 = 0x12345,
            flags = OcgConstants.DUEL_MODE_MR5,
            team1 = new OCG_Player { startingLP = 8000, startingDrawCount = 5, drawCountPerTurn = 1 },
            team2 = new OCG_Player { startingLP = 8000, startingDrawCount = 5, drawCountPerTurn = 1 },
            cardReader = Marshal.GetFunctionPointerForDelegate(_dataReader),
            scriptReader = Marshal.GetFunctionPointerForDelegate(_scriptReader),
            logHandler = Marshal.GetFunctionPointerForDelegate(_logHandler),
            cardReaderDone = Marshal.GetFunctionPointerForDelegate(_readerDone),
            enableUnsafeLibraries = 0
        };

        _parsers = ParserFactory.CreateParsers();

        // 4. Criação do Duelo
        IntPtr pDuel;
        if (OcgApi.OCG_CreateDuel(out pDuel, ref options) == 0)
        {
            LoadBaseScripts(pDuel);
            CreateDecks(pDuel);
            RodarDuelo(pDuel);
            OcgApi.OCG_DestroyDuel(pDuel);
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

        return OcgApi.OCG_LoadScript(
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
        GameMessage msgType = (GameMessage)buffer[0];

        if (_parsers.TryGetValue(msgType, out var value))
        {
            return MessageHandler.HandleMessage(value.Parse(buffer));
        }
        
        return MessageHandler.HandleMessage(_parsers[GameMessage.Unknown].Parse(buffer));
    }
    
    private static void CreateDecks(IntPtr pDuel)
    {
        CreateDeck(pDuel, 0, 0);
        CreateDeck(pDuel, 1, 2);
        
        // 0x01 é LOCATION_DECK
        var quantidadeNoDeck0 = OcgApi.OCG_DuelQueryCount(pDuel, 0, 0x01);
        Console.WriteLine($"Player 0 MAINDECK Size: {quantidadeNoDeck0}");
        var quantidadeNoDeck1 = OcgApi.OCG_DuelQueryCount(pDuel, 1, 0x01);
        Console.WriteLine($"Player 1 MAINDECK Size: {quantidadeNoDeck1}");
    }

    private static void CreateDeck(IntPtr pDuel, byte team, int d)
    {
        var deck = DummyDeck.CreateDeck(team, d);
        foreach (var card in deck)
        {
            var ocgNewCardInfo = card;
            OcgApi.OCG_DuelNewCard(pDuel, ref ocgNewCardInfo);
        }
    }
    
    static void RodarDuelo(IntPtr pDuel)
    {
        OcgApi.OCG_StartDuel(pDuel);
        Console.WriteLine("--- DUEL STARTED ---");

        bool duelando = true;
        int currentDuelist = 0;

        while (duelando)
        {
            int status = OcgApi.OCG_DuelProcess(pDuel);
            uint length;
            IntPtr messagePtr = OcgApi.OCG_DuelGetMessage(pDuel, out length);
            if (length > 0)
            {
                // 1. Criamos um array de bytes no C# com o tamanho que a DLL nos deu
                byte[] dadosLocais = new byte[length];
                // 2. Copiamos o que está naquele endereço 0x25d1... para o nosso array
                Marshal.Copy(messagePtr, dadosLocais, 0, (int)length);
                // 3. Agora sim, olhe para os bytes:
                ProcessMessages(dadosLocais);

                if (status == 1)
                {
                    if (MessageHandler.MessageRequiringInput != null)
                    {
                        duelando = HandlePlayerInput(pDuel);
                    }
                    else
                    {
                        Console.WriteLine("--- SOMETHING WENT WROND ---");
                        duelando = false;
                    }
                }
                else if (status == 3)
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
        
        switch (MessageHandler.MessageRequiringInput.Input)
        {
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
            case InputType.Win:
                Console.WriteLine("--- DUEL WIN! ---");
                return false;
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
                response = message.GetResponse(choice);
                if (response.Length == 0)
                    Console.WriteLine("--- INVALID CHOICE ---");
            }
            else
            {
                Console.WriteLine("--- INVALID CHOICE ---");
            }
        } while (response.Length == 0);

        OcgApi.OCG_DuelSetResponse(pDuel, response, (uint) response.Length); 
    }

    private static void HandlePlayerInputConfirmation(IntPtr pDuel)
    {
        Console.WriteLine("\n--- AWAITING PLAYER'S INPUT ---");
        Console.Write("Press enter to confirm... ");
        var input = Console.ReadLine();
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
                response = message.GetResponse(choice);
                if (response.Length == 0)
                    Console.WriteLine("--- INVALID CHOICE ---");
            }
            else
            {
                Console.WriteLine("--- INVALID CHOICE ---");
            }
        } while (response.Length == 0);

        OcgApi.OCG_DuelSetResponse(pDuel, response, (uint) response.Length); 
    }

    private static void HandlePlayerInputSort(IntPtr pDuel)
    {
        var message = (ISelectionsMessage)MessageHandler.MessageRequiringInput;
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

        OcgApi.OCG_DuelSetResponse(pDuel, response, (uint) response.Length); 
    }

    private static void HandlePlayerInputSelections(IntPtr pDuel)
    {
        var responseIds = new List<int>();
        var enter = false;
        var message = (ISelectionsMessage)MessageHandler.MessageRequiringInput;
        byte[] response = [];
        do
        {
            Console.WriteLine("\n--- AWAITING PLAYER'S INPUT ---");
            Console.Write("Input your selections: ");
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
        OcgApi.OCG_DuelSetResponse(pDuel, response, (uint) response.Length); 
    }
}