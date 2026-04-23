using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser;

namespace YgoSoul.Message;

public class MoveMessage : BaseMessage
{
    private readonly uint _cardCode;
    private readonly uint _oldPlayer;
    private readonly CardLocation _oldLocation;
    private readonly uint _oldSequence;
    private readonly uint _oldPosition;
    private readonly uint _newPlayer;
    private readonly CardLocation _newLocation;
    private readonly uint _newSequence;
    private readonly uint _newPosition;
    private readonly MoveParser.MoveReason _reason;
    
    public MoveMessage(
        uint cardCode, 
        uint oldPlayer, 
        CardLocation oldLocation, 
        uint oldSequence, 
        uint oldPosition,
        uint newPlayer, 
        CardLocation newLocation, 
        uint newSequence, 
        uint newPosition,
        MoveParser.MoveReason reason)
    {
        _cardCode = cardCode;
        _oldPlayer = oldPlayer;
        _oldLocation = oldLocation;
        _oldSequence = oldSequence;
        _oldPosition = oldPosition;
        _newPlayer = newPlayer;
        _newLocation = newLocation;
        _newSequence = newSequence;
        _newPosition = newPosition;
        _reason = reason;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Card {CardLibrary.GetCard(_cardCode).Name} was with player {_oldPlayer} on the " +
                      $"{_oldLocation}, in sequence {_oldSequence} and position {_oldPosition}.");
        sb.AppendLine($"It moved to {_newLocation}, in sequence {_newSequence} and position " +
                      $"{_newPosition}, and is now controlled by {_newPlayer}, because of {_reason.ToString()}");
        return sb.ToString();
    }
}