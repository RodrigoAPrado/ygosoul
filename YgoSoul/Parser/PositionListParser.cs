using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class PositionListParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msgType = (GameMessage) reader.ReadByte();//msg
        var size = reader.ReadByte();

        var cards = new List<FullLocationReference>();
        for (int i = size; i > 0; i--)
        {
            cards.Add(new FullLocationReference(
                reader.ReadByte(), 
                (CardLocation) reader.ReadByte(),
                reader.ReadUInt32(),
                (CardPosition) reader.ReadByte()));
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