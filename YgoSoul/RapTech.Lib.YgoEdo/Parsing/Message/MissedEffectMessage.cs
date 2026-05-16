using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class MissedEffectMessage : BaseMessage, IMissedEffectMessage
{
    public IFullLocationReference LocationReference => _locationReference;
    public uint CardCode { get; }
    private readonly FullLocationReference _locationReference;

    public MissedEffectMessage(FullLocationReference locationReference, uint cardCode)
    {
        _locationReference = locationReference;
        CardCode = cardCode;
    }

    public override string ToString()
    {
        return $"MissedEffect, LocationReference={LocationReference}, Card={CardLibrary.InternalGetCard(CardCode).Name}";
    }
}