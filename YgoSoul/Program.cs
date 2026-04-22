using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Data.Sqlite;
using YgoSoul;

class Program
{
    private static DataReader _dataReader;
    private static ScriptReader _scriptReader;
    private static LogHandler _logHandler;
    private static DataReaderDone _readerDone;
    
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

    private static void ContinueDuel(IntPtr pDuel)
    {
        int value = OcgApi.OCG_DuelProcess(pDuel);
        uint length;
        IntPtr messagePtr = OcgApi.OCG_DuelGetMessage(pDuel, out length);
        if (length > 0)
        {
            // 1. Criamos um array de bytes no C# com o tamanho que a DLL nos deu
            byte[] dadosLocais = new byte[length];
            // 2. Copiamos o que está naquele endereço 0x25d1... para o nosso array
            System.Runtime.InteropServices.Marshal.Copy(messagePtr, dadosLocais, 0, (int)length);
            // 3. Agora sim, olhe para os bytes:
            ProcessMessage(dadosLocais);
        }
    }
    
    private static void ProcessMessage(byte[] buffer) {
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
            ProcessarUnicaMensagem(msgData);
        }
    }

    private static void ProcessarUnicaMensagem(byte[] buffer)
    {
        // 2. O 'msgType' está no byte 4 (logo após o header de tamanho)
        GameMessage msgType = (GameMessage)buffer[0];

        switch (msgType)
        {
            case GameMessage.Hint:
                if(!HandleHint(buffer))
                    Console.WriteLine($"Mensagem {msgType.ToString()}, conteúdo: {BitConverter.ToString(buffer)}");
                break;
            case GameMessage.Retry:
                Console.WriteLine($"Mensagem {msgType.ToString()}, conteúdo: {BitConverter.ToString(buffer)}");
                break;
            case GameMessage.SelectIdleCmd:
                if(!HandleIdleCmd(buffer))
                    Console.WriteLine($"Mensagem {msgType.ToString()}, conteúdo: {BitConverter.ToString(buffer)}");
                break;
            case GameMessage.SelectChain:
                if(!HandleSelectChain(buffer))
                    Console.WriteLine($"Mensagem {msgType.ToString()}, conteúdo: {BitConverter.ToString(buffer)}");
                break;
            case GameMessage.NewTurn:
                Console.WriteLine($"Novo Turno {buffer[1] + 1}");
                break;
            case GameMessage.NewPhase:
                Console.WriteLine($"É a {((GamePhases) buffer[1]).ToString()}");
                break;
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
                break;
            default:
                Console.WriteLine("Mensagem Desconhecida, conteúdo: " + BitConverter.ToString(buffer));
                break;
        }
    }

    private static bool HandleHint(byte[] buffer)
    {
        switch ((GameHintType) buffer[1])
        {
            case GameHintType.HintEvent:
                return HandleHintEvent(buffer);
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

    private static int AddCardAction(StringBuilder sb, uint actionValue, int currentPos, byte[] buffer, PlayerActions pa)
    {
        sb.Append($"- Fazer {actionValue} {pa.ToString()}(s)");
        if (actionValue == 0)
        {
            sb.Append($";\n");
        }
        else
        {
            sb.Append($", que são os monstros:\n");
            for (var i = 0; i < actionValue; i++)
            {
                currentPos += 4;
                uint monsterValue = BitConverter.ToUInt32(buffer, currentPos);
                currentPos += 5;
                uint locationValue = buffer[currentPos];
                currentPos += 1;
                uint indexValue = buffer[currentPos];
                sb.Append($"    -{CardLibrary.GetCard(monsterValue).Name}, que está na sua {((CardLocation)locationValue).ToString()} com indice {indexValue};\n");
            }
        }
        currentPos+=4;
        return currentPos;
    }
    
    
    private static bool HandleIdleCmd(byte[] buffer)
    {
        byte player = buffer[1];
        int currentPos = 2;
        StringBuilder sb = new StringBuilder();
        sb.Append($"O jogador {player} pode: \n");
        foreach (PlayerActions value in Enum.GetValues(typeof(PlayerActions)))
        {
            uint actionValue = BitConverter.ToUInt32(buffer, currentPos);
            currentPos = AddCardAction(sb, actionValue, currentPos, buffer, value);
        }
        
        currentPos += 1;
        if (buffer[currentPos] == 1)
        {
            sb.Append($"- Ir para a BattlePhase;\n");
        }
        currentPos += 1;
        if (buffer[currentPos] == 1)
        {
            sb.Append($"- Ir para a EndPhase;\n");
        }
        Console.Write(sb.ToString());
        return true;
    }
    
    // Normal Summon
    // Special Summon
    // Change Position
    // Set
    // Spell/Trap
    // ExtraDeck
    // BattlePhase
    // EndPhase
    
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

        ContinueDuel(pDuel);
        ContinueDuel(pDuel);
        ContinueDuel(pDuel);
        ContinueDuel(pDuel);
        ContinueDuel(pDuel);
        ContinueDuel(pDuel);
        ContinueDuel(pDuel);
        ContinueDuel(pDuel);
        ContinueDuel(pDuel);
        ContinueDuel(pDuel);
        //ContinueDuel(pDuel);
    }
}