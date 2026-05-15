using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser;

public class PositionListParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msgType = (OCG_GameMessage) reader.ReadByte();//msg
        var size = reader.ReadUInt32();

        var cards = new List<FullLocationReference>();
        for (var i = size; i > 0; i--)
        {
            cards.Add(new FullLocationReference(
                reader.ReadByte(), 
                (OCG_CardLocation) reader.ReadByte(),
                reader.ReadUInt32(),
                (OCG_CardPosition) reader.ReadUInt32()));
        }

        switch (msgType)
        {
            case OCG_GameMessage.CardSelected:
                return new CardSelectedMessage(cards);
            case OCG_GameMessage.BecomeTarget:
                return new BecomeTargetMessage(cards);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}