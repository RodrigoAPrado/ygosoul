using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class ChainNegatedMessage : BaseMessage, IChainNegatedMessage
{
    public byte ChainSize { get; }

    public ChainNegatedMessage(byte chainSize)
    {
        ChainSize = chainSize;
    }

    public override string ToString()
    {
        return $"Chain Negated, Chain Size={ChainSize}";
    }
}