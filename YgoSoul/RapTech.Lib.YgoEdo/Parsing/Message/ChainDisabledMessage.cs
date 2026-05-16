using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ChainDisabledMessage : BaseMessage, IChainDisabledMessage
{
    public byte ChainSize { get; }

    public ChainDisabledMessage(byte chainSize)
    {
        ChainSize = chainSize;
    }

    public override string ToString()
    {
        return $"ChainDisabled, ChainSize={ChainSize}";
    }
}