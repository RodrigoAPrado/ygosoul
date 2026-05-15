using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class PositionListParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msgType = (GameMessage) reader.ReadByte();//msg
        var size = reader.ReadUInt32();

        var cards = new List<FullLocationReference>();
        for (var i = size; i > 0; i--)
        {
            cards.Add(new FullLocationReference(
                reader.ReadByte(), 
                (CardLocation) reader.ReadByte(),
                reader.ReadUInt32(),
                (CardPosition) reader.ReadUInt32()));
        }

        switch (msgType)
        {
            case GameMessage.CardSelected:
                return new CardSelectedMessage(cards);
            case GameMessage.BecomeTarget:
                return new BecomeTargetMessage(cards);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}