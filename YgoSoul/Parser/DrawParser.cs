using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Parser;

public class DrawParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var cardsDrawn = new List<DrawnCard>();
        byte player = buffer[1];
        byte count = buffer[2];
        int currentPos = 6;
        for (int i = 0; i < count; i++)
        {
            uint cardCode = BitConverter.ToUInt32(buffer, currentPos);
                
            currentPos += 8;
            cardsDrawn.Add(new DrawnCard(cardCode));
        }

        return new DrawMessage(player, cardsDrawn);
    }
}