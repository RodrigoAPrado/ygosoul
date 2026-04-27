using YgoSoul.DuelRunner;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

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
        return $"MissedEffect, LocationReference={LocationReference}, Card={CardLibrary.GetCard(CardCode).Name}";
    }
}