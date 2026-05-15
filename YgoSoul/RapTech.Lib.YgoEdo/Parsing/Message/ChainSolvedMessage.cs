using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ChainSolvedMessage : BaseMessage
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