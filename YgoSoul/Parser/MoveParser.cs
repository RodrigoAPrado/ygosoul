using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Parser;

public class MoveParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var cardCode = BitConverter.ToUInt32(buffer, 1);
        var currentPos = 5;
        var currentController = buffer[currentPos++];
        var currentLocation = (CardLocation) buffer[currentPos++];
        var currentSequence = buffer[currentPos++];
        var currentPosition = buffer[currentPos++];
        currentPos += 2;
        currentPos += 4;
        var newController = buffer[currentPos++];
        var newLocation = (CardLocation) buffer[currentPos++];
        var newSequence = buffer[currentPos++];
        var newPosition = buffer[currentPos++];
        var reason = (MoveReason) BitConverter.ToUInt32(buffer, currentPos);
        //TODO: Tem mais alguns bytes aqui que não estão sendo lidos;
        
        return new MoveMessage(cardCode, 
            currentController, 
            currentLocation, 
            currentSequence, 
            currentPosition, 
            newController, 
            newLocation, newSequence, 
            newPosition, 
            reason
            );
    }

    public enum MoveReason : uint
    {
        Unknown = 0,
        NormalSummon = 0x10,
    }
}