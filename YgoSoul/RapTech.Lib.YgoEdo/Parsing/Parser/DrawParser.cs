using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Parser;

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
            OCG_CardPosition cardPosition = (OCG_CardPosition) reader.ReadUInt32();
            cardsDrawn.Add(new DrawnCard(cardCode, cardPosition));
        }

        return new DrawMessage(player, cardsDrawn);
    }
}