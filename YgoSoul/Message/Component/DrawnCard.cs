using YgoSoul.DuelRunner;
using YgoSoul.Flag;

namespace YgoSoul.Message.Component;

public class DrawnCard
{
    private readonly uint _cardCode;
    private readonly CardPosition _cardPosition;
    
    public DrawnCard(uint cardCode, CardPosition cardPosition)
    {
        _cardCode = cardCode;
        _cardPosition = cardPosition;
    }

    public override string? ToString()
    {
        var card = CardLibrary.GetCard(_cardCode);
        return $"{card.Name} that was {_cardPosition}.";
    }
}