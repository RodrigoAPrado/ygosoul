using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class ChainedMessage : BaseMessage, IChainedMessage
{
    public byte ChainSize { get; }

    public ChainedMessage(byte chainSize)
    {
        ChainSize = chainSize;
    }

    public override string ToString()
    {
        return $"Chain Size={ChainSize}";
    }
}