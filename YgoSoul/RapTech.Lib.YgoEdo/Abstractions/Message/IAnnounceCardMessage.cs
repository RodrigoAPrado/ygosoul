using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;

public interface IAnnounceCardMessage : IDuelMessage
{
    byte Player { get; }
    IReadOnlyList<(string, uint)> AvailableCards { get; }
    List<(int, string)> Query(string value);
}