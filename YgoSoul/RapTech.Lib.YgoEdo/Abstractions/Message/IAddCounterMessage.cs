using YgoSoul.RapTech.Lib.YgoEdo.CardInfo.Interface;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Interface;

public interface IAddCounterMessage : IDuelMessage
{
    CounterType CounterType { get; }
    byte Player { get; }
    Location Location { get; }
    byte Sequence { get; }
    ushort Count { get; } 
}