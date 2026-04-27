using System.Text;
using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser;

namespace YgoSoul.Message;

public class MoveMessage : BaseMessage
{
    public uint CardCode { get; }
    public uint OldPlayer { get; }
    public CardLocation OldLocation { get; }
    public uint OldSequence { get; }
    public CardPosition OldPosition { get; }
    public uint NewPlayer { get; }
    public CardLocation NewLocation { get; }
    public uint NewSequence { get; }
    public CardPosition NewPosition { get; }
    public Reason Reason { get; }

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
        CardCode = cardCode;
        OldPlayer = oldPlayer;
        OldLocation = oldLocation;
        OldSequence = oldSequence;
        OldPosition = oldPosition;
        NewPlayer = newPlayer;
        NewLocation = newLocation;
        NewSequence = newSequence;
        NewPosition = newPosition;
        Reason = reason;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Card {CardLibrary.GetCard(CardCode).Name} was with player {OldPlayer} on the " +
                      $"{OldLocation}, in sequence {OldSequence} and position {OldPosition}.");
        sb.AppendLine($"It moved to {NewLocation}, in sequence {NewSequence} and position " +
                      $"{NewPosition}, and is now controlled by {NewPlayer}, because of {Reason.ToString()}");
        return sb.ToString();
    }
}