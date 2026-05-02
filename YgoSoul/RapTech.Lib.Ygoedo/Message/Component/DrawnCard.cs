using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

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