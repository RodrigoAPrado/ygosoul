using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class BecomeTargetParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var size = reader.ReadByte();

        var targets = new List<FullLocationReference>();
        for (int i = size; i > 0; i--)
        {
            targets.Add(new FullLocationReference(
                reader.ReadByte(), 
                (CardLocation) reader.ReadByte(),
                reader.ReadUInt32(),
                (CardPosition) reader.ReadByte()));
        }

        return new BecomeTargetMessage(targets);
    }
}