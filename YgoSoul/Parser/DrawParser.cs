using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class DrawParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var cardsDrawn = new List<DrawnCard>();
        reader.ReadByte();
        
        byte player = reader.ReadByte();
        byte count = reader.ReadByte();
        reader.Skip(3); // Padding.
        for (int i = 0; i < count; i++)
        {
            uint cardCode = reader.ReadUInt32();
            CardPosition cardPosition = (CardPosition) reader.ReadUInt32();
            cardsDrawn.Add(new DrawnCard(cardCode, cardPosition));
        }

        return new DrawMessage(player, cardsDrawn);
    }
}