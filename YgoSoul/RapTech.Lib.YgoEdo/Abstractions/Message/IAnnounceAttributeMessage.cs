using YgoSoul.RapTech.Lib.YgoEdo.CardInfo.Interface;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Interface;

public interface IAnnounceAttributeMessage : IDuelMessage
{
    byte Player { get; }
    byte Count { get; }
    IReadOnlyList<CardAttribute> Attributes { get; }
    bool CanCancel { get; }
}