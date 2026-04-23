namespace YgoSoul.Message.Component;

public class DrawnCard
{
    private readonly uint _cardCode;

    public DrawnCard(uint cardCode)
    {
        _cardCode = cardCode;
    }

    public override string? ToString()
    {
        var card = CardLibrary.GetCard(_cardCode);
        return card.Name;
    }
}