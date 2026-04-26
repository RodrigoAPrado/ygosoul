using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

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