using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

public class SwapMessage : BaseMessage
{
    public CardReference Card1 { get; }
    public CardReference Card2 { get; }

    public SwapMessage(CardReference card1, CardReference card2)
    {
        Card1 = card1;
        Card2 = card2;
    }

    public override string ToString()
    {
        return $"Card 1={Card1} swap with Card 2={Card2}";
    }
}