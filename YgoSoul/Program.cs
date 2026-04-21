using System.Runtime.InteropServices;
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
        Console.WriteLine("OCG duel Progress Response: " + value);
        uint length;
        IntPtr messagePtr = OcgApi.OCG_DuelGetMessage(pDuel, out length);
        if (length > 0)
        {
            // 1. Criamos um array de bytes no C# com o tamanho que a DLL nos deu
            byte[] dadosLocais = new byte[length];
            // 2. Copiamos o que está naquele endereço 0x25d1... para o nosso array
            System.Runtime.InteropServices.Marshal.Copy(messagePtr, dadosLocais, 0, (int)length);
            // 3. Agora sim, olhe para os bytes:
            Console.WriteLine("Conteúdo da Mensagem: " + BitConverter.ToString(dadosLocais));

            ProcessMessage(dadosLocais);
        }
    }
    
    private static void ProcessMessage(byte[] buffer) {
        // 1. Pega o tamanho total (os 4 primeiros bytes do buffer original)
        uint totalSize = BitConverter.ToUInt32(buffer, 0);

        // 2. O 'msgType' está no byte 4 (logo após o header de tamanho)
        GameMessage msgType = (GameMessage)buffer[4];

        switch (msgType)
        {
            case GameMessage.Draw:
                byte player = buffer[5];
                byte count = buffer[6];
            
                // O segredo do PADDING: O ID da primeira carta começa no byte 10
                // [0-3]: Size | [4]: Type | [5]: Player | [6]: Count | [7-9]: Padding
                int currentPos = 10;

                for (int i = 0; i < count; i++)
                {
                    // BitConverter já faz a inversão dos bytes (Little Endian) automaticamente!
                    uint cardId = BitConverter.ToUInt32(buffer, currentPos);
                
                    // Pula 8 bytes: 4 do ID + 4 da localização (o 0x0A que você viu)
                    currentPos += 8;

                    Console.WriteLine($"Jogador {player} comprou a carta: {cardId}");
                }
                break;
        }
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

    public static void CreateDeck(IntPtr pDuel, byte team)
    {
        
        for(int i = 1; i<=40; i++)
        {
            var data = new OCG_NewCardInfo()
            {
                team = team,
                duelist = 0,
                code = 89631139,
                con = team,
                loc = 0x01, 
                pos = 0x08 
            };
            OcgApi.OCG_DuelNewCard(pDuel, ref data);
        }
    }
    
    static void RodarDuelo(IntPtr pDuel)
    {
        OcgApi.OCG_StartDuel(pDuel);
        Console.WriteLine("--- Duelo Iniciado ---");

        ContinueDuel(pDuel);
        return;
        bool duelRunning = true;
        while (duelRunning)
        {
            // 1. Processa o próximo passo da engine
            int status = OcgApi.OCG_DuelProcess(pDuel);

            // 2. Verifica se há mensagens (animações, compras, ataques)
            uint length;
            IntPtr messagePtr = OcgApi.OCG_DuelGetMessage(pDuel, out length);

            if (length > 0)
            {
                byte[] buffer = new byte[length];
                Marshal.Copy(messagePtr, buffer, 0, (int)length);
                AnalisarMensagens(buffer);
            }

            // 3. Verifica o estado do duelo
            switch (status)
            {
                case 1: // OCG_DUEL_STATUS_CONTINUE
                    continue; 
                case 2: // OCG_DUEL_STATUS_AWAITING
                    Console.WriteLine("Aguardando decisão do jogador...");
                    // Aqui você enviaria um OCG_DuelSetResponse
                    duelRunning = false; // Paramos o loop para simular espera
                    break;
                case 3: // OCG_DUEL_STATUS_END
                    Console.WriteLine("O duelo terminou!");
                    duelRunning = false;
                    break;
            }
        }
    }

    static void AnalisarMensagens(byte[] buffer)
    {
        int offset = 0;
        while (offset + 4 <= buffer.Length) // Checa se tem pelo menos 4 bytes para o ID da msg
        {
            // LEITURA COMO INT32
            int msgInt = BitConverter.ToInt32(buffer, offset);
            offset += 4; 

            if (msgInt == 0) continue; // Pula paddings de 4 bytes

            GameMessage msgType = (GameMessage)msgInt;

            switch (msgType)
            {
                case GameMessage.Draw:
                    // 1. Lê o player normalmente
                    byte drawPlayer = buffer[offset++]; 
    
                    // 2. CAÇA O VALOR REAL DO COUNT
                    // Pulamos todos os zeros até achar o '5' (ou 40, se for o deck todo)
                    while (offset < buffer.Length && buffer[offset] == 0) offset++;
    
                    byte count = buffer[offset++];
                    Console.WriteLine($"Jogador {drawPlayer} comprou {count} carta(s).");

                    // 3. ALINHAMENTO DE 64-BITS
                    // O primeiro ID de carta em sistemas 64-bit geralmente começa 
                    // em um offset múltiplo de 4 ou 8.
                    offset = (offset + 3) & ~3; 

                    for (int i = 0; i < count; i++)
                    {
                        if (offset + 4 <= buffer.Length)
                        {
                            uint cardCode = BitConverter.ToUInt32(buffer, offset);
                            offset += 4;
                            // Se o ID ainda vier gigante, tente offset += 4 extra aqui (se for 64-bit puro)
                            Console.WriteLine($" > Carta: {cardCode}");
                        }
                    }
                    break;
            }
        }
    }
}