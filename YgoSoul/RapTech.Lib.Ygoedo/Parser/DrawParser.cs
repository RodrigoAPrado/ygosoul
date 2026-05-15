using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class DrawParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
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