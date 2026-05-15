using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class CardHintMessage : BaseMessage
{
    public FullLocationReference FullLocationReference { get; }
    public OCG_CardHint CardHint { get; }
    public ulong Description { get; }

    public CardHintMessage(FullLocationReference fullLocationReference, OCG_CardHint cardHint, ulong description)
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