using YgoSoul.DuelRunner;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace YgoSoul.Parser;

public class ShuffleCardsParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msgType = (GameMessage) reader.ReadByte();
        var player = reader.ReadByte();
        var count = reader.ReadUInt32();
        var cards = new List<uint>();
        for (var i = count; i > 0; i--)
        {
            cards.Add(reader.ReadUInt32());
        }
        
        switch (msgType)
        {
            case GameMessage.ShuffleHand:
                return new ShuffleHandMessage(player, cards);
            case GameMessage.ShuffleExtra:
                return new ShuffleExtraMessage(player, cards);
            default:
                throw new ArgumentOutOfRangeException();
        }

    }
}