using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class FlipSummoningMessage : BaseMessage
{
    public CardReference Card { get; }
    
    public FlipSummoningMessage(CardReference card) 
    {
        Card = card;
    }

    public override string ToString()
    {
        return $"{CardLibrary.InternalGetCard(Card.CardCode).Name} is being flip summoned for " +
               $"{Card.LocationReference.Controller} on " +
               $"{Card.LocationReference.Location} in sequence " +
               $"{Card.LocationReference.Sequence} and position " +
               $"{Card.LocationReference.Position}";
    }
}