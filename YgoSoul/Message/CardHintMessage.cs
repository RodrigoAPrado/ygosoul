using YgoSoul.Flag;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

public class CardHintMessage : BaseMessage
{
    public FullLocationReference FullLocationReference { get; }
    public CardHint CardHint { get; }
    public ulong Description { get; }

    public CardHintMessage(FullLocationReference fullLocationReference, CardHint cardHint, ulong description)
    {
        FullLocationReference = fullLocationReference;
        CardHint = cardHint;
        Description = description;
    }

    public override string ToString()
    {
        return $"{FullLocationReference}. Hint={CardHint}, Description={Description}";
    }
}