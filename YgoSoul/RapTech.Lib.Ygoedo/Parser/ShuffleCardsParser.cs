using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class ShuffleCardsParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
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