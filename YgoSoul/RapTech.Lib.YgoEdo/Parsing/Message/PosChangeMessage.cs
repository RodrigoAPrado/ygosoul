using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class PosChangeMessage : BaseMessage
{
    public uint CardCode { get; }
    public byte CurrentController { get; }
    public OCG_CardLocation CurrentLocation { get; }
    public byte CurrentSequence { get; }
    public OCG_CardPosition PreviousPosition { get; }
    public OCG_CardPosition CurrentPosition { get; }

    public PosChangeMessage(
	    uint cardCode, 
	    byte currentController, 
	    OCG_CardLocation currentLocation, 
	    byte currentSequence, 
	    OCG_CardPosition previousPosition, 
	    OCG_CardPosition currentPosition
	    )
    {
	    CardCode = cardCode;
	    CurrentController = currentController;
	    CurrentLocation = currentLocation;
	    CurrentSequence = currentSequence;
	    PreviousPosition = previousPosition;
	    CurrentPosition = currentPosition;
    }

    public override string ToString()
    {
	    return $"Card {CardLibrary.InternalGetCard(CardCode).Name} was changed from {PreviousPosition} to {CurrentPosition}";
    }
}