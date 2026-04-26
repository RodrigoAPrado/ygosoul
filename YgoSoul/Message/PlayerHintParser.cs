using YgoSoul.Flag;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Message;

public class PlayerHintParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        return new PlayerHintMessage(reader.ReadByte(), (PlayerHint) reader.ReadByte(), reader.ReadULong64());
    }
}