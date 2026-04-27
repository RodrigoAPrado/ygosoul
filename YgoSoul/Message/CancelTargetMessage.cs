using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

public class CancelTargetMessage : BaseMessage
{
    public FullLocationReference Card { get; }
    public FullLocationReference Target { get; }

    public CancelTargetMessage(FullLocationReference card, FullLocationReference target)
    {
        Card = card;
        Target = target;
    }

    public override string ToString()
    {
        return $"TargetCancel, Card={Card}, Target={Target}";
    }
}