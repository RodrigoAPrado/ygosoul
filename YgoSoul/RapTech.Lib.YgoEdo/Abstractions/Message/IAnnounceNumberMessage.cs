using YgoSoul.RapTech.Lib.YgoEdo.Manager.Interface;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;

public interface IAnnounceNumberMessage : ISelectionDuelMessage
{
    byte Player { get; }
    IReadOnlyList<uint> AvailableNumbers { get; }
}