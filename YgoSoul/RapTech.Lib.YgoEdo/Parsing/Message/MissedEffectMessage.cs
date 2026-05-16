using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class MissedEffectMessage : BaseMessage
{
    public FullLocationReference LocationReference { get; init; }
    public uint CardCode { get; }

    public MissedEffectMessage(FullLocationReference locationReference, uint cardCode)
    {
        LocationReference = locationReference;
        CardCode = cardCode;
    }

    public override string ToString()
    {
        return $"MissedEffect, LocationReference={LocationReference}, Card={CardLibrary.InternalGetCard(CardCode).Name}";
    }
}