using System.Text;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser;

namespace YgoSoul.Message;

public class MoveMessage : BaseMessage
{
    private readonly uint _cardCode;
    private readonly uint _oldPlayer;
    private readonly CardLocation _oldLocation;
    private readonly uint _oldSequence;
    private readonly CardPosition _oldPosition;
    private readonly uint _newPlayer;
    private readonly CardLocation _newLocation;
    private readonly uint _newSequence;
    private readonly CardPosition _newPosition;
    private readonly Reason _reason;
    
    public MoveMessage(
        uint cardCode, 
        uint oldPlayer, 
        CardLocation oldLocation, 
        uint oldSequence, 
        CardPosition oldPosition,
        Reason reason,
        uint newPlayer, 
        CardLocation newLocation, 
        uint newSequence, 
        CardPosition newPosition)
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