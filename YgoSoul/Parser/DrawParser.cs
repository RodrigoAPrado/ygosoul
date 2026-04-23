using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Parser;

public class DrawParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
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
    }
}