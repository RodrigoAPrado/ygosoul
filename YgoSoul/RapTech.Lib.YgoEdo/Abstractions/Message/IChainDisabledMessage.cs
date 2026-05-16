using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;

public interface IChainDisabledMessage : IDuelMessage
{
    byte ChainSize { get; }
}