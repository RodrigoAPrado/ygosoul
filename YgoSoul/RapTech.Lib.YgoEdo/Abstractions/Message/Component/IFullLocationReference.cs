using YgoSoul.RapTech.Lib.YgoEdo.CardInfo.Interface;
using YgoSoul.RapTech.Lib.YgoEdo.Manager.Interface.Flag;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;

public interface IFullLocationReference
{
    byte Controller { get; }
    Location Location { get; }
    uint Sequence { get; }
    CardPosition Position { get; }
}