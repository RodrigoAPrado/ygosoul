using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Parser;

public class SummoningParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var cardCode = BitConverter.ToUInt32(buffer, 1);
        var currentPos = 5;
        var player = buffer[currentPos++];
        var location = (CardLocation) buffer[currentPos++];
        var sequence = buffer[currentPos++];
        var position = buffer[currentPos++];
        var reason = (MoveParser.MoveReason) BitConverter.ToUInt32(buffer, currentPos);

        return new SummoningMessage($"{CardLibrary.GetCard(cardCode).Name} is being {reason} for player " +
                                    $"{player} on {location} in sequence {sequence} and position {position}");

    }
}