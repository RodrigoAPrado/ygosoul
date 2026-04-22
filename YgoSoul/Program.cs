using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Data.Sqlite;
using YgoSoul;
using YgoSoul.Factory;
using YgoSoul.Handler;
using YgoSoul.Handler.Enum;
using YgoSoul.Message;
using YgoSoul.Message.Component;
using YgoSoul.Parser;
using YgoSoul.Parser.Abstr;

class Program
{
    private static DataReader _dataReader;
    private static ScriptReader _scriptReader;
    private static LogHandler _logHandler;
    private static DataReaderDone _readerDone;

    private static List<IdleCmdChoiceCard> _playerChoices;
    
    private static Dictionary<GameMessage, IParser> _parsers;
        
        
    // Dentro do seu Main ou classe de teste
    static void Main(string[] args)
    {
        // 1. Verifique a versão (Bom para testar se a DLL carregou)
        OcgApi.OCG_GetVersion(out int major, out int minor);
        Console.WriteLine($"OCGCore Version: {major}.{minor}");

        // Inicializa banco de dados
        CardDatabase.Initialize("cards.cdb");
        
        // 2. Configure os delegates (Importante: manter referências static)
        _dataReader = MyCardReader;
        
        _scriptReader = (payload, duel, name) => {
            string path = Path.Combine("script", name);
            byte[] content;

            if (!File.Exists(path)) {
                // Pega o ID da carta pelo nome do arquivo (ex: c46986414.lua -> 46986414)
                string codeStr = name.Replace("c", "").Replace(".lua", "");
        
                // Retorna um script que define a função initial_effect vazia
                string dummyScript = $@"function c{codeStr}.initial_effect(c)end";
                content = System.Text.Encoding.UTF8.GetBytes(dummyScript);
            } else {
                content = File.ReadAllBytes(path);
            }

            return OcgApi.OCG_LoadScript(duel, content, (uint)content.Length, name);
        };

        _logHandler = OnLogReceived;
        _readerDone = OnReaderDone;

        // 3. Monte as opções
        var options = new OCG_DuelOptions
        {
            seed0 = 0x12345,
            flags = OcgConstants.DUEL_MODE_MR2,
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
            CreateDecks(pDuel);
            RodarDuelo(pDuel);
            OcgApi.OCG_DestroyDuel(pDuel);
        }
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
    
    private static int ProcessMessage(byte[] buffer)
    {
        var resultActions = 0;
        // 1. Pega o tamanho total (os 4 primeiros bytes do buffer original)
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
            var result = ProcessarUnicaMensagem(msgData);
        }

        return resultActions;
    }

    private static MessageHandleEnum ProcessarUnicaMensagem(byte[] buffer)
    {
        // 2. O 'msgType' está no byte 4 (logo após o header de tamanho)
        GameMessage msgType = (GameMessage)buffer[0];

        if (_parsers.TryGetValue(msgType, out var value))
        {
            return MessageHandler.HandleMessage(value.Parse(buffer));
        }
        
        switch (msgType)
        {
            case GameMessage.Retry:
                Console.WriteLine($"Mensagem {msgType.ToString()}, conteúdo: {BitConverter.ToString(buffer)}");
                return 1;
            case GameMessage.Hint:
                if(!HandleHint(buffer))
                    Console.WriteLine($"Mensagem {msgType.ToString()}, conteúdo: {BitConverter.ToString(buffer)}");
                return 0;
            case GameMessage.SelectChain:
                if(!HandleSelectChain(buffer))
                    Console.WriteLine($"Mensagem {msgType.ToString()}, conteúdo: {BitConverter.ToString(buffer)}");
                return 0;
            case GameMessage.SelectPlace:
                _currentGameMessage = msgType;
                var result2 = HandleSelectPlace(buffer);
                if (!result2.Item1)
                {
                    Console.WriteLine($"Mensagem {msgType.ToString()}, conteúdo: {BitConverter.ToString(buffer)}");
                    return 0;
                }
                return result2.Item2;
            case GameMessage.NewTurn:
                Console.WriteLine($"Novo Turno {buffer[1] + 1}");
                return 0;
            case GameMessage.NewPhase:
                Console.WriteLine($"É a {((GamePhases) buffer[1]).ToString()}");
                return 0;
            case GameMessage.Draw:
                byte player = buffer[1];
                byte count = buffer[2];
            
                int currentPos = 6;

                for (int i = 0; i < count; i++)
                {
                    // BitConverter já faz a inversão dos bytes (Little Endian) automaticamente!
                    uint cardId = BitConverter.ToUInt32(buffer, currentPos);
                
                    // Pula 8 bytes: 4 do ID + 4 da localização (o 0x0A que você viu)
                    currentPos += 8;

                    Console.WriteLine($"Jogador {player} comprou a carta: {CardLibrary.GetCard(cardId).Name}");
                }
                return 0;
            default:
                return MessageHandler.HandleMessage(_parsers[GameMessage.Unknown].Parse(buffer));
        }
    }

    private static bool HandleHint(byte[] buffer)
    {
        switch ((GameHintType) buffer[1])
        {
            case GameHintType.HintEvent:
                return HandleHintEvent(buffer);
            case GameHintType.HintSelectMsg:
                Console.WriteLine($"Jogador escolheu a carta {CardLibrary.GetCard(BitConverter.ToUInt32(buffer, 3)).Name}.");
                return true;
            default:
                return false;
        }
    }

    private static bool HandleHintEvent(byte[] buffer)
    {
        switch (buffer[3])
        {
            case 27:
                Console.WriteLine($"Jogador {buffer[2]}, é a Draw Phase.");
                return true;
            default:
                return false;
        }
    }

    private static bool HandleSelectChain(byte[] buffer)
    {
        var player = buffer[1];
        var availableEffects = buffer[2];
        var mandatoryEffects = buffer[3];
        if (availableEffects == 0 && mandatoryEffects == 0)
        {
            if (buffer[6] == 33 && buffer[10] == 33)
            {
                Console.WriteLine($"Jogador {player}, você tem {availableEffects} efeitos opcionais e {mandatoryEffects} obrigatórios. Vou passar a vez.");
                return true;
            }
            return false;
        }

        return false;
    }

    private static (bool, int) HandleSelectPlace(byte[] buffer)
    {
        var player = buffer[1];
        var amount = buffer[2];
     
        uint mask = BitConverter.ToUInt32(buffer, 3);
        Console.WriteLine($"--- Jogador {player}: Escolha {amount} zona(s) ---");

        var actionAmount = 0;
        
        for (int i = 0; i < 5; i++)
        {
            // Se o bit estiver em 0, a zona está disponível
            bool disponivel = ((mask >> i) & 1) == 0;
            if (disponivel)
            {
                actionAmount++;
                Console.WriteLine($"{i} para Zona de Monstro {i}.");
            }
        }

        // 2. Validar Spell/Trap Zones (Bits 8 a 12) - Caso fosse uma Magia
        for (int i = 8; i <= 12; i++)
        {
            bool disponivel = ((mask >> i) & 1) == 0;
            if (disponivel)
            {
                actionAmount++;
                Console.WriteLine($"{i-3} para Zona de Magia/Armadilha {i - 8}.");
            }
        }
    
        // 3. Validar Field Zone (Bit 13)
        if (((mask >> 13) & 1) == 0)
        {
            actionAmount++;
            Console.WriteLine("{i-3} para Zona de Campo.");
        }

        return (true, actionAmount);
    }
    
    private static void CreateDecks(IntPtr pDuel)
    {
        /*var decks = DummyDeck.CreateDeck(0);
        decks.AddRange(DummyDeck.CreateDeck(1));
        */
        CreateDeck(pDuel, 0);
        CreateDeck(pDuel, 1);
        
        // 0x01 é LOCATION_DECK
        var quantidadeNoDeck0 = OcgApi.OCG_DuelQueryCount(pDuel, 0, 0x01);
        Console.WriteLine($"Cartas detectadas no Deck 0: {quantidadeNoDeck0}");
        var quantidadeNoDeck1 = OcgApi.OCG_DuelQueryCount(pDuel, 1, 0x01);
        Console.WriteLine($"Cartas detectadas no Deck 1: {quantidadeNoDeck1}");
    }

    private static void CreateDeck(IntPtr pDuel, byte team)
    {
        var deck = DummyDeck.CreateDeck(team);
        foreach (var card in deck)
        {
            var ocgNewCardInfo = card;
            OcgApi.OCG_DuelNewCard(pDuel, ref ocgNewCardInfo);
        }
    }
    
    static void RodarDuelo(IntPtr pDuel)
    {
        OcgApi.OCG_StartDuel(pDuel);
        Console.WriteLine("--- Duelo Iniciado ---");

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
                System.Runtime.InteropServices.Marshal.Copy(messagePtr, dadosLocais, 0, (int)length);
                // 3. Agora sim, olhe para os bytes:
                var result = ProcessMessage(dadosLocais);

                if (status == 1)
                {
                    if (result > 0)
                    {
                        Console.WriteLine("\n--- AGUARDANDO DECISÃO DO JOGADOR ---");
                        Console.Write("Digite o número da ação desejada: ");
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out int escolha))
                        {
                            if (_currentGameMessage == GameMessage.SelectIdleCmd)
                            {
                                if (escolha >= _playerChoices.Count)
                                {
                                    Console.Write("Escolha invalida...");
                                    
                                }
                                else
                                {
                                    var choice = _playerChoices[escolha];
                                    byte[] response = new byte[]{(byte)choice.PlayerAction,0,(byte)choice.CardIndex,0};
                                    OcgApi.OCG_DuelSetResponse(pDuel, response, 4); 
                                }
                            }

                            if (_currentGameMessage == GameMessage.SelectPlace)
                            {
                                //TODO:
                                byte[] response = { (byte)currentDuelist, 0x04, 0x02 }; 
                                OcgApi.OCG_DuelSetResponse(pDuel, response, (uint)response.Length);
                                /*
                                var placeResult = GetLocationValue(escolha);
                                byte[] response = new byte[] { (byte)currentDuelist,  };*/
                            }
                        }
                    }
                }
                else if (status == 3)
                {
                    Console.WriteLine("--- Fim do Duelo ---");
                    duelando = false;
                }
            }
        }
    }

    private static (int, int) GetLocationValue(int value)
    {
        switch (value)
        {
           case 0:
               return ((int)CardLocation.MonsterZone, value);
           case 1:
               return ((int)CardLocation.MonsterZone, value);
           case 2:
               return ((int)CardLocation.MonsterZone, value);
           case 3:
               return ((int)CardLocation.MonsterZone, value);
           case 4:
               return ((int)CardLocation.MonsterZone, value);
           case 5:
               return ((int)CardLocation.SpellTrapZone, value-5);
           case 6:
               return ((int)CardLocation.SpellTrapZone, value-5);
           case 7:
               return ((int)CardLocation.SpellTrapZone, value-5);
           case 8:
               return ((int)CardLocation.SpellTrapZone, value-5);
           case 9:
               return ((int)CardLocation.SpellTrapZone, value-5);
           default:
               throw new NotImplementedException();
        }
    }
}