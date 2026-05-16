using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class MoveMessage : BaseMessage
{
    public uint CardCode { get; }
    public uint OldPlayer { get; }
    public OCG_CardLocation OldLocation { get; }
    public uint OldSequence { get; }
    public OCG_CardPosition OldPosition { get; }
    public uint NewPlayer { get; }
    public OCG_CardLocation NewLocation { get; }
    public uint NewSequence { get; }
    public OCG_CardPosition NewPosition { get; }
    public OCG_Reason Reason { get; }

    public MoveMessage(
        uint cardCode, 
        uint oldPlayer, 
        OCG_CardLocation oldLocation, 
        uint oldSequence, 
        OCG_CardPosition oldPosition,
        OCG_Reason reason,
        uint newPlayer, 
        OCG_CardLocation newLocation, 
        uint newSequence, 
        OCG_CardPosition newPosition)
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
        sb.AppendLine($"Card {CardLibrary.InternalGetCard(CardCode).Name} was with player {OldPlayer} on the " +
                      $"{OldLocation}, in sequence {OldSequence} and position {OldPosition}.");
        sb.AppendLine($"It moved to {NewLocation}, in sequence {NewSequence} and position " +
                      $"{NewPosition}, and is now controlled by {NewPlayer}, because of {Reason.ToString()}");
        return sb.ToString();
    }
}