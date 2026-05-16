using YgoSoul.RapTech.Lib.YgoEdo.CardInfo.Interface;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;

public interface IAnnounceRaceMessage : ISelectionDuelMessage
{
    byte Player { get; }
    byte Count { get; }
    IReadOnlyList<MonsterType> AvailableTypes { get; }
}