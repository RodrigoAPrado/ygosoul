using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class SetMessage : BaseMessage
{
    public CardReference Card { get; }
    
    public SetMessage(CardReference card) 
    {
        Card = card;
    }

    public override string ToString()
    {
        return $"{CardLibrary.InternalGetCard(Card.CardCode).Name} is being set for " +
               $"{Card.LocationReference.Controller} on " +
               $"{Card.LocationReference.Location} in sequence " +
               $"{Card.LocationReference.Sequence} and position " +
               $"{Card.LocationReference.Position}";
    }
}