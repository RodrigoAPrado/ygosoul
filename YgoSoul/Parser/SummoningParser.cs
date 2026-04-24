using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SummoningParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte(); //msg
        var cardCode = reader.ReadUInt32();
        
        var player = reader.ReadByte();
        var location = (CardLocation) reader.ReadByte();
        var sequence = reader.ReadUInt32();
        var position = (CardPosition) reader.ReadUInt32();

        return new SummoningMessage($"{CardLibrary.GetCard(cardCode).Name} is being summoned for " +
                                    $"{player} on {location} in sequence {sequence} and position {position}");

    }
}