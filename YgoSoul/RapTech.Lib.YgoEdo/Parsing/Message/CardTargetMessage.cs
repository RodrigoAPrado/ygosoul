using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class CardTargetMessage : BaseMessage
{
    public FullLocationReference Card { get; }
    public FullLocationReference Target { get; }

    public CardTargetMessage(FullLocationReference card, FullLocationReference target)
    {
        Card = card;
        Target = target;
    }

    public override string ToString()
    {
        return $"CardTarget, Card={Card}, Target={Target}";
    }
}