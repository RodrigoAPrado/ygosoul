using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.CardInfo.Interface;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class CardHintMessage : BaseMessage, ICardHintMessage
{
    public IFullLocationReference LocationReference => _locationReference;
    public DuelCardHint CardHint => _cardHint.ToDuelCardHint();
    public string Description => DescriptionHandler.GetDescription(_description, _cardHint);
    
    private readonly FullLocationReference _locationReference;
    private readonly OCG_CardHint _cardHint;
    private readonly ulong _description;

    public CardHintMessage(FullLocationReference fullLocationReference, OCG_CardHint cardHint, ulong description)
    {
        _locationReference = fullLocationReference;
        _cardHint = cardHint;
        _description = description;
    }

    public override string ToString()
    {
        return $"{_locationReference}. Hint={_cardHint}, Description={DescriptionHandler.GetDescription(_description, _cardHint)}, DescriptionDex={_description:x16}";
    }
}