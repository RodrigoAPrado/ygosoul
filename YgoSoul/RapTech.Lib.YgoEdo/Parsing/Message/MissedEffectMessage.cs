using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

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