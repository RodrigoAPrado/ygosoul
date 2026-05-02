using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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