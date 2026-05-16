using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class ChainSolvedMessage : BaseMessage, IChainSolvedMessage
{
    public byte ChainCount { get; }

    public ChainSolvedMessage(byte chainCount)
    {
        ChainCount = chainCount;
    }

    public override string ToString()
    {
        return $"ChainSolved, ChainCount={ChainCount}";
    }
}