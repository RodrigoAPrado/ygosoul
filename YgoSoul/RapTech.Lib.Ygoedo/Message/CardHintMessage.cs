using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Handler;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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
        return $"{FullLocationReference}. Hint={CardHint}, Description={DescriptionHandler.GetDescription(Description, CardHint)}, DescriptionDex={Description:x16}";
    }
}