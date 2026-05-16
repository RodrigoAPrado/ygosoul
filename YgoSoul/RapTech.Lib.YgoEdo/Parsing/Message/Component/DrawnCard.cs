using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

public class DrawnCard
{
    private readonly uint _cardCode;
    private readonly OCG_CardPosition _cardPosition;
    
    public DrawnCard(uint cardCode, OCG_CardPosition cardPosition)
    {
        _cardCode = cardCode;
        _cardPosition = cardPosition;
    }

    public override string? ToString()
    {
        var card = CardLibrary.InternalGetCard(_cardCode);
        return $"{card.Name} that was {_cardPosition}.";
    }
}