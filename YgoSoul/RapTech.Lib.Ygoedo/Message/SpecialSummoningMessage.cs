using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class SpecialSummoningMessage : BaseMessage
{
    public CardReference Card { get; }
    
    public SpecialSummoningMessage(CardReference card) 
    {
        Card = card;
    }

    public override string ToString()
    {
        return $"{CardLibrary.InternalGetCard(Card.CardCode).Name} is being special summoned for " +
               $"{Card.LocationReference.Controller} on " +
               $"{Card.LocationReference.Location} in sequence " +
               $"{Card.LocationReference.Sequence} and position " +
               $"{Card.LocationReference.Position}";
    }
}