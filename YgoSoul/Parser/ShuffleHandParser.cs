using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class ShuffleHandParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var count = reader.ReadUInt32();
        var cards = new List<uint>();
        for (var i = count; i > 0; i--)
        {
            cards.Add(reader.ReadUInt32());
        }

        return new ShuffleHandMessage(player, cards);
    }
}