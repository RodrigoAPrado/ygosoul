using YgoSoul.Flag;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class PosChangeMessage : BaseMessage
{
    public uint CardCode { get; }
    public byte CurrentController { get; }
    public CardLocation CurrentLocation { get; }
    public byte CurrentSequence { get; }
    public CardPosition PreviousPosition { get; }
    public CardPosition CurrentPosition { get; }

    public PosChangeMessage(
	    uint cardCode, 
	    byte currentController, 
	    CardLocation currentLocation, 
	    byte currentSequence, 
	    CardPosition previousPosition, 
	    CardPosition currentPosition
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
	    return $"Card {CardLibrary.GetCard(CardCode).Name} was changed from {PreviousPosition} to {CurrentPosition}";
    }
}

/*
 *
 *
 *
			message->write<uint32_t>(pcard->data.code);
			message->write<uint8_t>(pcard->current.controler);
			message->write<uint8_t>(pcard->current.location);
			message->write<uint8_t>(pcard->current.sequence);
			message->write<uint8_t>(pcard->previous.position);
			message->write<uint8_t>(pcard->current.position);
 * 
 */